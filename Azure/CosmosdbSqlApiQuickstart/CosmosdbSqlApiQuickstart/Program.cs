using Newtonsoft.Json;
using Microsoft.Azure.Cosmos;
using System.Net;
using Microsoft.Azure.Cosmos.Scripts;

namespace CosmosdbSqlApiQuickstart
{
    public class Family
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }
        public string? LastName { get; set; }
        public Parent[] Parents { get; set; } = [];
        public Child[] Children { get; set; } = [];
        public Address? Address { get; set; }
        public bool IsRegistered { get; set; } = false;
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Parent
    {
        public string? FamilyName { get; set; }
        public string? FirstName { get; set; }
    }

    public class Child
    {
        public string? FamilyName { get; set; }
        public string? FirstName { get; set; }
        public string? Gender { get; set; }
        public int Grade { get; set; }
        public Pet[] Pets { get; set; } = [];
    }

    public class Pet
    {
        public string? GivenName { get; set; }
    }

    public class Address
    {
        public string? State { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
    }

    class Program()
    {
        private static readonly string EndpointUri = Environment.GetEnvironmentVariable("EndpointUri")!;
        private static readonly string PrimaryKey = Environment.GetEnvironmentVariable("PrimaryKey")!;
        //Client Cosmos
        private static CosmosClient? _cosmosClient;
        //Database
        private static Database? _database;
        //Contenedor
        private static Container? _container;

        private static string databaseId = "FamilyDb";
        private static string containerId = "Family";

        private static string storeProcedureFile =
            Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName, "insertFamily.js");

        public static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Empezamos a construir la demo de Cosmos...\n");
                //Crear la instancia del Cliente Cosmos
                _cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);

                //Crear la base de datos
                _database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
                Console.WriteLine("Base de datos creada: {0}\n", _database.Id);

                //Crear el contenedor
                _container = await _database.CreateContainerIfNotExistsAsync(containerId, "/LastName");
                Console.WriteLine("Container creado: {0}\n", _container.Id);

                //Crear el SP
                await CreateStoreProcedureFromFileAsync(storeProcedureFile);

                //Insertar 
                await AddItemsToContainerAsync();

                //Lista
                await QueryItemsAsync();

                //Update
                await ReplaceFamilyItemsAsync();

                //Llamada al SP
                await ExecuteStoreProcedureAsync();

                //Delete
                await DeleteFamilyItemAsync();

                //Delete Database
                await DeleteDatabaseAndCleanAsync();

            }
            catch (CosmosException ex)
            {
                Exception baseException = ex.GetBaseException();
                Console.WriteLine("{0} error encontrado: {1}", ex.SubStatusCode, baseException);
                throw;
            }
            finally
            {
                Console.WriteLine("Fin del proyecto presiona una tecla para salir");
                Console.ReadKey();
            }
        }

        private static async Task AddItemsToContainerAsync()
        {
            Family andersenFamily = new Family
            {
                Id = "Andersen.1",
                LastName = "Andersen",
                Parents = new Parent[]
                {
                    new Parent { FirstName = "Thomas" },
                    new Parent { FirstName = "Mary Kay" }
                },
                Children = new Child[]
                {
                    new Child
                    {
                        FirstName = "Henriette Thaulow",
                        Gender = "female",
                        Grade = 5,
                        Pets = new Pet[]
                        {
                            new Pet { GivenName = "Fluffy" }
                        }
                    }
                },
                Address = new Address { State = "WA", County = "King", City = "Seattle" },
                IsRegistered = false
            };

            try
            {
                ItemResponse<Family> andersenFamilyResponse = await _container!.ReadItemAsync<Family>(andersenFamily.Id, new PartitionKey(andersenFamily.LastName));
                Console.WriteLine($"Ya existe una familia en la base de datos: {andersenFamilyResponse.Resource.Id}");
            }
            catch (CosmosException ex) 
            when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ItemResponse<Family> andersenFamilyResponse = await _container!.CreateItemAsync(andersenFamily, new PartitionKey(andersenFamily.LastName));
                Console.WriteLine($"Familia: {andersenFamilyResponse.Resource.Id}. Ha consumido { andersenFamilyResponse.RequestCharge } RUs creada");
            }


            Family wakefieldFamily = new Family
            {
                Id = "Wakefield.7",
                LastName = "Wakefield",
                Parents = new Parent[]
                            {
                    new Parent { FamilyName = "Wakefield", FirstName = "Robin" },
                    new Parent { FamilyName = "Miller", FirstName = "Ben" }
                            },
                Children = new Child[]
                            {
                    new Child
                    {
                        FamilyName = "Merriam",
                        FirstName = "Jesse",
                        Gender = "female",
                        Grade = 8,
                        Pets = new Pet[]
                        {
                            new Pet { GivenName = "Goofy" },
                            new Pet { GivenName = "Shadow" }
                        }
                    },
                    new Child
                    {
                        FamilyName = "Miller",
                        FirstName = "Lisa",
                        Gender = "female",
                        Grade = 1
                    }
                            },
                Address = new Address { State = "NY", County = "Manhattan", City = "NY" },
                IsRegistered = true
            };

            try
            {
                // Read the item to see if it exists
                ItemResponse<Family> wakefieldFamilyResponse = await _container.ReadItemAsync<Family>(wakefieldFamily.Id, new PartitionKey(wakefieldFamily.LastName));
                Console.WriteLine("Item in database with id: {0} already exists\n", wakefieldFamilyResponse.Resource.Id);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Create an item in the container representing the Wakefield family. Note we provide the value of the partition key for this item, which is "Wakefield"
                ItemResponse<Family> wakefieldFamilyResponse = await _container.CreateItemAsync<Family>(wakefieldFamily, new PartitionKey(wakefieldFamily.LastName));

                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse. We can also access the RequestCharge property to see the amount of RUs consumed on this request.
                Console.WriteLine("Created item in database with id: {0} Operation consumed {1} RUs.\n", wakefieldFamilyResponse.Resource.Id, wakefieldFamilyResponse.RequestCharge);
            }
        }

        private static async Task QueryItemsAsync()
        {
            var sqlQueryText = "SELECT * FROM c WHERE c.LastName = 'Andersen'";

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);

            FeedIterator<Family> queryResultSetIterator = _container!.GetItemQueryIterator<Family>(queryDefinition);

            List<Family> families = new List<Family>();

            while (queryResultSetIterator.HasMoreResults) 
            {
                FeedResponse<Family> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach(Family family in currentResultSet)
                {
                    families.Add(family);
                    Console.WriteLine($"\t Read {family}\n");
                }
            }
        }

        private static async Task ReplaceFamilyItemsAsync()
        {
            ItemResponse<Family> wakefieldFamilyResponse = await _container!.ReadItemAsync<Family>("Wakefield.7", new PartitionKey("Wakefield"));
            var itemBody = wakefieldFamilyResponse.Resource;

            itemBody.IsRegistered = true;
            itemBody.Children[0].Grade = 6;

            wakefieldFamilyResponse = await _container.ReplaceItemAsync(itemBody, itemBody.Id, new PartitionKey(itemBody.LastName));

            Console.WriteLine($"Update Family {itemBody.LastName}, {itemBody.Id} con tbody {wakefieldFamilyResponse}");
        }

        private static async Task DeleteFamilyItemAsync()
        {
            var partitionKeyValue = "Wakefield";
            var familyId = "Wakefield.7";

            ItemResponse<Family> wakefieldFamilyResponse = await _container!.DeleteItemAsync<Family>(familyId, new PartitionKey(partitionKeyValue));
            Console.WriteLine($"Hemos borrado Family {partitionKeyValue}, {familyId} \n");
        }

        private static async Task DeleteDatabaseAndCleanAsync() 
        {
            DatabaseResponse databaseResponse = await _database!.DeleteAsync();

            Console.WriteLine($"Database borrada {databaseId} \n");

            _cosmosClient!.Dispose();
        }

        private static async Task CreateStoreProcedureFromFileAsync(string scriptPath)
        {
            if (!File.Exists(scriptPath))
            {
                Console.WriteLine($"Error: El archivo {scriptPath} no existe");
                return;
            }

            string scriptBody = await File.ReadAllTextAsync(scriptPath);
            var storedProcedureDefinition = new StoredProcedureProperties
            {
                Id = "insertFamily",
                Body = scriptBody
            };

            try
            {
                await _container!.Scripts.ReplaceStoredProcedureAsync(storedProcedureDefinition);
                Console.WriteLine("Procedimiento Almacenado 'insertFamily' actualizado correctamente");
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                await _container!.Scripts.CreateStoredProcedureAsync(storedProcedureDefinition);
                Console.WriteLine("Procedimiento Almacenado 'insertFamily' creado correctamente");
            }
        }

        private static async Task ExecuteStoreProcedureAsync()
        {
            string storeProcedureId = "insertFamily";
            string partitionKey = "Andersen";

            var parameters = new dynamic[]
            {
                new
                {
                    id = "Andersen.2",
                    LastName = "Andersen",
                    Parents = new[] { new { FirstName = "John" }, new { FirstName = "Jane" } },
                    Children = new[] { new { FirstName = "Anna", Gender = "female", Grade = 3 } },
                    Address = new { State = "WA", County = "King", City = "Seattle" },
                    IsRegistered = true
                }
            };

            try
            {
                var response = await _container!.Scripts.ExecuteStoredProcedureAsync<StoredProcedureResponse>(
                        storeProcedureId,
                        new PartitionKey(partitionKey),
                        parameters
                    );
                Console.WriteLine("SP creado satisfactoriamente");
            }
            catch (CosmosException ex)
            {
                Console.WriteLine($"error ejecutando SP: {ex.Message}, con Codigo: {ex.StatusCode}");
            }
        }
        public class StoredProcedureResponse
        {
            public string? Status { get; set; }
            public string? Message { get; set; }
        }
    }
}
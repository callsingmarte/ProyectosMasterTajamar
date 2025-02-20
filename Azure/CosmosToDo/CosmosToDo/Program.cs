using Azure.Identity;
using CosmosToDo.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICosmosDbService>(
    InitializeCosmosClientInstanceAsync(builder.Configuration.GetSection("CosmosDb")).GetAwaiter().GetResult()
    );

// Agregar configuración de variables de entorno
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

// Acceder a los valores de configuración
var cosmosDbAccount = builder.Configuration["CosmosDb:Account"];
var cosmosDbKey = builder.Configuration["CosmosDb:Key"];

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

static async Task<CosmosDbService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
{
    string databaseName = configurationSection.GetSection("DatabaseName").Value ?? "DefaultbaseName";
    string containerName = configurationSection.GetSection("ContainerName").Value ?? "DefaultContainerName";
    string account = configurationSection.GetSection("Account").Value ?? "DefaultAccount";

    string key = configurationSection.GetSection("Key").Value ?? "DefaultKey";

    ManagedIdentityCredential miCredential;
    Microsoft.Azure.Cosmos.CosmosClient client;

    if (string.IsNullOrEmpty(key))
    {
        miCredential = new ManagedIdentityCredential();
        client = new Microsoft.Azure.Cosmos.CosmosClient(account, miCredential);
    }
    else
    {
        client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
    }

    CosmosDbService cosmosDbService = new CosmosDbService(client, databaseName, containerName);
    Microsoft.Azure.Cosmos.DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
    await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

    return cosmosDbService;

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

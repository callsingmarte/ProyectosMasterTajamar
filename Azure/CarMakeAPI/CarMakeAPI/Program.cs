using CarMakeAPI.Models;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        builder =>
        {
            builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CarMakeAPI1", Version = "v1" });
});

// Agregar configuración de variables de entorno
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

Console.WriteLine("CarsDb:Account (desde config): " + builder.Configuration["CarsDb:Account"]);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<ICarCosmosService>(options =>
{
    string? URL = !String.IsNullOrEmpty(builder.Configuration.GetSection("CarsDb").GetValue<string>("Account")) ? builder.Configuration.GetSection("CarsDb").GetValue<string>("Account") : Environment.GetEnvironmentVariable("COSMOSDB_ACCOUNT");
    string? primaryKey = !String.IsNullOrEmpty(builder.Configuration.GetSection("CarsDb").GetValue<string>("Key")) ? builder.Configuration.GetSection("CarsDb").GetValue<string>("Key") : Environment.GetEnvironmentVariable("COSMOSDB_KEY");
    string dbname = builder.Configuration.GetSection("CarsDb").GetValue<string>("DatabaseName")!;
    string containerName = builder.Configuration.GetSection("CarsDb").GetValue<string>("ContainerName")!;

    var cosmosClient = new CosmosClient(URL, primaryKey, new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway });

    return new CarCosmosService(cosmosClient, dbname, containerName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarMakeAPI1 v1"));
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

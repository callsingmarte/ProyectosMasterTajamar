using Azure.Identity;
using StackExchange.Redis;
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

var keyVaultEndpoint = new Uri( string.IsNullOrEmpty(builder.Configuration["AzureKeyVault:VaultUri"]) ? Environment.GetEnvironmentVariable("VaultUri") : builder.Configuration["AzureKeyVault:VaultUri"]);
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

var redisConnectionString = builder.Configuration["CacheConnection"];

if (string.IsNullOrEmpty(redisConnectionString))
{
    throw new Exception("No se encontró la cadena de conexion de Redis en Key Vault");
}

builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
{
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisCache:CacheConnection"));
    return ConnectionMultiplexer.Connect(configuration);
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

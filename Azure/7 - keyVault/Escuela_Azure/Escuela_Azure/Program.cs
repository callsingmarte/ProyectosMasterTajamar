using Escuela_Azure.Models;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Cargar configuración desde appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Obtener Key Vault
var keyVaultEndpoint = Environment.GetEnvironmentVariable("VaultUri");
if (!string.IsNullOrEmpty(keyVaultEndpoint))
{    
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultEndpoint), new DefaultAzureCredential());
}

// Imprimir la cadena para depuración
Console.WriteLine($"Valor en Key Vault: {builder.Configuration["DefaultConnection"]}");

// Configurar DbContext
builder.Services.AddDbContext<StudentDbContext>(options =>
{
    var connectionString = builder.Configuration["DefaultConnection"];

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("No se pudo obtener la cadena de conexión desde Key Vault.");
    }

    options.UseSqlServer(connectionString);
});

// 🔹 Agregar servicios de autenticación y autorización
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// 🔹 Asegurar que la autenticación se usa antes de la autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
using IHostedServiceTest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuracion del logging
//Limpiar los proveedores de logs predeterminados
builder.Logging.ClearProviders();
//Añladir el proveedor de consola
builder.Logging.AddConsole();
//Aseguremos de que los logs se muestran correctamente
builder.Logging.SetMinimumLevel(LogLevel.Information);

//Añadimos el IHostedService
builder.Services.AddHostedService<TimeHostedService>();

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

using Amazon.CognitoIdentityProvider;
using Microsoft.Extensions.Options;
using WebAppCognitoDemo.Models;
using WebAppCognitoDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AwsCognitoSettings>(builder.Configuration.GetSection("AWS"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<AwsCognitoSettings>>().Value);

//Agregar servicio de Cognito
builder.Services.AddSingleton<IAmazonCognitoIdentityProvider, AmazonCognitoIdentityProviderClient>();
builder.Services.AddSingleton<ICognitoService, CognitoService>();

//Configuracion de autenticacion para cookies
builder.Services.AddAuthentication("Cookies").AddCookie("Cookies", options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

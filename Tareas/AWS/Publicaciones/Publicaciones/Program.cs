using Amazon.CognitoIdentityProvider;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Options;
using Publicaciones.Interfaces;
using Publicaciones.Models;
using Publicaciones.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AwsCognitoSettings>(builder.Configuration.GetSection("AWS"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<AwsCognitoSettings>>().Value);

builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddSingleton<IpublicacionesRepository, PublicacionesRepository>();

//Agregar servicio de Cognito
builder.Services.AddSingleton<IAmazonCognitoIdentityProvider, AmazonCognitoIdentityProviderClient>();
builder.Services.AddSingleton<ICognitoService, CognitoService>();

//Configuracion de autenticacion para cookies
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie("Cookies", options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
}).AddOpenIdConnect(options =>
{
    options.Authority = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_QvveoNnIi";
    options.ClientId = builder.Configuration["AWS:CognitoClientId"];
    options.ClientSecret = builder.Configuration["AWS:CognitoAppClientSecret"];
    options.ResponseType = "code";
    options.SaveTokens = true;
    options.Scope.Add("openid");
    options.Scope.Add("email");
    options.Scope.Add("phone");
    options.Scope.Add("profile");

    options.CallbackPath = "/signin-oidc";
    options.SignedOutCallbackPath = "/signout-callback-oidc";

    options.SignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

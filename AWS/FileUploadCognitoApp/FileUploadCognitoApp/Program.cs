using Amazon.S3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);



// Configurar servicios de autenticaci�n
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOpenIdConnect(options =>
{
    options.Authority = "";
    options.ClientId = "";
    options.ClientSecret = "";
    options.ResponseType = "code";
    options.SaveTokens = true;
    options.Scope.Add("openid");   // Alcance obligatorio
    options.Scope.Add("email");    // Alcance para correo electr�nico
    options.Scope.Add("phone");    // Alcance para n�mero de tel�fono
    options.Scope.Add("profile");  // Alcance para informaci�n del perfil

    options.CallbackPath = "/signin-oidc";
    options.SignedOutCallbackPath = "/signout-callback-oidc";  // Esta es la URL a la que Cognito redirigir� despu�s de logout
                                                               //options.PostLogoutRedirectUri = "https://localhost:7279/Home/Index"; // Ajusta esta URL seg�n tu aplicaci�n
    options.SignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

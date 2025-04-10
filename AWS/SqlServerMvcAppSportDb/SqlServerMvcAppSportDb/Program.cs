using Microsoft.EntityFrameworkCore;
using SqlServerMvcAppSportDb.Data;
using SqlServerMvcAppSportDb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AWSSecretsManagerService>();

var config = builder.Configuration;
var secretService = new AWSSecretsManagerService(config);
string secretName = "sql-server-local-connection-string";
string connectionString = await secretService.GetSecretValueAsync(secretName);

builder.Services.AddDbContext<SportDbContext>(options => options.UseSqlServer(connectionString));

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

using Amazon.KeyManagementService;
using Microsoft.EntityFrameworkCore;
using MvcAppAws_MartinSanchez.Data;
using MvcAppAws_MartinSanchez.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddSingleton<SecretManagerService>();

var config = builder.Configuration;
IAmazonKeyManagementService kmsClient = new AmazonKeyManagementServiceClient();
var secretService = new SecretManagerService(config, kmsClient);
string secretName = "PracticaRdsSecreto";
string connectionString = await secretService.GetSecretValueAsync(secretName);
//string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

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

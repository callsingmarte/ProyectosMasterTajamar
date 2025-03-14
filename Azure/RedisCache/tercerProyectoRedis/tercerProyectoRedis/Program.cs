using Microsoft.EntityFrameworkCore;
using tercerProyectoRedis.Data;
using tercerProyectoRedis.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(!string.IsNullOrEmpty(builder.Configuration.GetConnectionString("DefaultConnection")) ? builder.Configuration.GetConnectionString("DefaultConnection") : Environment.GetEnvironmentVariable("DefaultConnection")));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = !string.IsNullOrEmpty(builder.Configuration["RedisCacheSettings:ConnectionString"]) ? builder.Configuration["RedisCacheSettings:ConnectionString"] : Environment.GetEnvironmentVariable("RedisConnection");
    options.InstanceName = "RedisCacheInstance:";
});

builder.Services.AddTransient<CacheService>();

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

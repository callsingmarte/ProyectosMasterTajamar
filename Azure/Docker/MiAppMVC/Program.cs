using Microsoft.EntityFrameworkCore;
using MiAppMVC.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SalesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalesDb"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

builder.WebHost.UseUrls("http://0.0.0.0:80");

using (var scope = app.Services.CreateScope())
{
    var salesContext = scope.ServiceProvider.GetRequiredService<SalesContext>();
    salesContext.Database.EnsureCreated();
    salesContext.Seed();
}

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

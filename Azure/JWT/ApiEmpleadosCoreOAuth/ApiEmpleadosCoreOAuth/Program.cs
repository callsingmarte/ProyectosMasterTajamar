using ApiEmpleadosCoreOAuth.Data;
using ApiEmpleadosCoreOAuth.Repositories;
using ApiEmpleadosCoreOAuth.Token;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddDbContext<EmpleadosContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("Conexion"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
        c =>
        {
            c.SwaggerDoc(
                name: "v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Api Empleados Seguridad OAuth",
                    Version = "v1",
                    Description = "Ejemplo de seguridad con token"
                }
            );
        }
    );

builder.Services.AddTransient<RepositoryEmpleados>();

HelperToken helper = new HelperToken(configuration);

//Añadimos autenticacion al servicio
builder.Services.AddAuthentication(helper.GetAuthOptions()).AddJwtBearer(helper.GetJwtOptions());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
            c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api v1");
                c.RoutePrefix = "";
            }
        );
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(
            c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api v1");
                c.RoutePrefix = "";
            }
        );
}

app.UseHttpsRedirection();
app.UseRouting();

//Importante este orden 1º authenticacion y 2º Authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

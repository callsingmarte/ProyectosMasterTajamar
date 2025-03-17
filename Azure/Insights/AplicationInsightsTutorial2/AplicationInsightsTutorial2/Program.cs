var builder = WebApplication.CreateBuilder(args);

// Agregar Application Insights con la clave de Instrumentación
builder.Services.AddApplicationInsightsTelemetry(options =>
{
    options.ConnectionString = !string.IsNullOrEmpty(builder.Configuration["ApplicationInsights:ConnectionString"]) ? builder.Configuration["ApplicationInsights:ConnectionString"] : Environment.GetEnvironmentVariable("ApplicationInsightsConnection");
});

// Habilitar logs de Application Insights
builder.Services.AddLogging(logging =>
{
    logging.AddApplicationInsights();
});

// Agregar controladores
builder.Services.AddControllers();

var app = builder.Build();

// Configuración del pipeline de middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
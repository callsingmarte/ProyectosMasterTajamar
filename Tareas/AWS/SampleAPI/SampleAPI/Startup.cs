using Amazon.DynamoDBv2;
using SampleAPI.Configurations;
using SampleAPI.Data.Queries;
using SampleAPI.Data.Repositories;

namespace SampleAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddAWSService<IAmazonDynamoDB>();
        services.AddSingleton(GetDbConfiguration());

        services.AddScoped<BaseRepository, Repository>();
        services.AddScoped<BaseQuery, Query>();
    }

    private DbConfiguration GetDbConfiguration()
    {
        DbConfiguration dbConf = new DbConfiguration()
        {
            ServiceURL = Configuration.GetValue<string>(ConfigurationKeys.DynamoDBServiceURLKey),
            TableName = Configuration.GetValue<string>(ConfigurationKeys.DynamoDBTableNameKey)
        };
        return dbConf;
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}
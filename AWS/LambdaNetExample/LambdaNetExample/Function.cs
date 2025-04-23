using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LambdaNetExample;

public class Function
{    
    public string FunctionHandler(MyInput input, ILambdaContext context)
    {
        string environment = Environment.GetEnvironmentVariable("ENVIRONMENT") ?? "dev";
        string apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? "NO_KEY";

        return $"Entorno: {environment}, Clave API: {apiKey}, Valor Recibido: {input.Key}";
    }
}

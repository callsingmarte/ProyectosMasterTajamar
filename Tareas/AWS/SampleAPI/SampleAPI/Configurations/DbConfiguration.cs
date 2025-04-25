namespace SampleAPI.Configurations
{
    public class DbConfiguration
    {
        //Cuando extraigamos los valores para la URL de DynamoDB y el nombre de la tabla de los archivos
        //appsettings.<environment>.json, se almacenarán en estas variables.

        public string ServiceURL { get; set; }
        public string TableName { get; set; }
    }
}

namespace MvcAwsS3.Helpers
{
    public enum Folders
    {
        Images=0, Documents=1, Temporal=2
    }

    public class PathProvider
    {
        IWebHostEnvironment? _environment;

        public PathProvider(IWebHostEnvironment environment) 
        {
            _environment = environment;
        }

        //Metodo para devolver las rutas a los ficheros
        public string MapPath(string filename, Folders folder) 
        {
            string? carpeta = "";
            if (folder == Folders.Documents)
            {
                carpeta = "documents";
            }
            else if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Temporal) 
            {
                carpeta = "temporal";
            }

            string path = Path.Combine(_environment.WebRootPath, carpeta, filename);
            return path;
        }
    }
}

using AutoFixture;

namespace MiAppMVC.Models
{
    public static class Seeder
    {
        public static void Seed(this SalesContext salesContext)
        {
            if (!salesContext.Products.Any())
            {
                Fixture fixture = new Fixture();
                fixture.Customize<Product>(product => product.Without(p => p.ProductId));
                //--- The next two lines add 100 rows to your database
                List<Product> products = fixture.CreateMany<Product>(100).ToList();
                salesContext.AddRange(products);
                salesContext.SaveChanges();
            }
        }
    }
}
//Este código utiliza la biblioteca AutoFixture, que es una herramienta para
//generar datos de prueba de manera automática.
//Aquí te explico lo que hace cada parte del código:
//Creación de una Instancia de Fixture: Fixture fixture = new Fixture();
//Personalización de la Clase Product: fixture.Customize<Product>(product => product.Without(p => p.ProductId));
//Generación de Productos: List<Product> products = fixture.CreateMany<Product>(100).ToList();
//Esta línea genera 100 instancias de la clase Product utilizando la configuración personalizada establecida anteriormente.
//CreateMany<Product>(100) crea una colección de 100 productos.
//Agregar Productos a la Base de Datos:
//salesContext.AddRange(products);
//salesContext.SaveChanges();
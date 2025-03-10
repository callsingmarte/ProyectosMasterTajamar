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
//Este c�digo utiliza la biblioteca AutoFixture, que es una herramienta para
//generar datos de prueba de manera autom�tica.
//Aqu� te explico lo que hace cada parte del c�digo:
//Creaci�n de una Instancia de Fixture: Fixture fixture = new Fixture();
//Personalizaci�n de la Clase Product: fixture.Customize<Product>(product => product.Without(p => p.ProductId));
//Generaci�n de Productos: List<Product> products = fixture.CreateMany<Product>(100).ToList();
//Esta l�nea genera 100 instancias de la clase Product utilizando la configuraci�n personalizada establecida anteriormente.
//CreateMany<Product>(100) crea una colecci�n de 100 productos.
//Agregar Productos a la Base de Datos:
//salesContext.AddRange(products);
//salesContext.SaveChanges();
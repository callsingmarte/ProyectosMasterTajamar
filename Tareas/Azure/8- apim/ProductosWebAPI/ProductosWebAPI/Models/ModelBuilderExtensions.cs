using Microsoft.EntityFrameworkCore;

namespace ProductosWebAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Categories_DB> categories = new List<Categories_DB>()
            {
                new Categories_DB{CategoryID=1,CategoryName="Watersports"},
                new Categories_DB{CategoryID=2,CategoryName="Soccer"},
                new Categories_DB{CategoryID=3,CategoryName="Chess"},
                new Categories_DB{CategoryID=4,CategoryName="Tenis"}
            };
            modelBuilder.Entity<Categories_DB>().HasData(categories);


            List<Products_DB> products = new List<Products_DB>()
            {
                new Products_DB{Id=1, Name="Kayak", CategoryID = 1,Price=286M},
                new Products_DB{Id=2,Name="Lifejacket",CategoryID = 1,Price=48.95M},
                new Products_DB{Id=3,Name="Soccer Ball",CategoryID = 2,Price=19.50M},
                new Products_DB{Id=4,Name="Corner Flags",CategoryID = 2,Price=34.95M},
                new Products_DB{Id=5,Name="Stadium",CategoryID = 3,Price=79500M},
                new Products_DB{Id=6,Name="Thinking Cap",CategoryID = 3,Price=16.00M},
                new Products_DB{Id=7,Name="TUnsteady Chair",CategoryID = 3,Price=29.95M},
                new Products_DB{Id=8,Name="Human Chess Board",CategoryID = 3,Price=75M},
                new Products_DB{Id=9,Name="Bling Bling King",CategoryID = 3,Price=1200M}
            };
            modelBuilder.Entity<Products_DB>().HasData(products);

        }
    }
}

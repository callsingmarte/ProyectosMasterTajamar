using EcommerceBasicoAWS.Interfaces;
using EcommerceBasicoAWS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBasicoAWS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<MultimediaProducto> MultimediaProductos { get; set; }
        public DbSet<ProductoCategoria> ProductosCategorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallesPedidos> DetallesPedidos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<ItemCarrito> ItemsCarrito { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>() {
                new IdentityRole { Name = IUserRoles.ADMIN, NormalizedName = IUserRoles.ADMIN.ToUpper() },
                new IdentityRole { Name = IUserRoles.STAFF, NormalizedName = IUserRoles.STAFF.ToUpper() },
                new IdentityRole { Name = IUserRoles.CLIENTE, NormalizedName = IUserRoles.CLIENTE.ToUpper() }
            };

            builder.Entity<IdentityRole>().HasData(roles);
            List<IdentityUser> users = new List<IdentityUser>()
            {
                    //Admin
                    new IdentityUser {
                        UserName="admin.staff", NormalizedUserName= "ADMIN.STAFF",
                        Email = "admin@nexusshop.com", NormalizedEmail="ADMIN@NEXUSSHOP.COM",
                        PhoneNumber="653124875", EmailConfirmed = true
                    },
                    //Staff
                    new IdentityUser {
                        UserName="lucia.sanchiz.staff", NormalizedUserName= "LUCIA.SANCHIZ.STAFF",
                        Email = "lucia.sanchiz@nexusshop.com", NormalizedEmail="LUCIA.SANCHIZ@NEXUSSHOP.COM",
                        PhoneNumber="685214739", EmailConfirmed = true
                    },
                    //Cliente
                    new IdentityUser {
                        UserName="paco.montoro", NormalizedUserName= "PACO.MONTORO@GMAIL.COM",
                        Email = "paco.montoro@gmail.com", NormalizedEmail="PACO.MONTORO@GMAIL.COM",
                        PhoneNumber="632514785", EmailConfirmed = true
                    }
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Admin1234$");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Lucia1234$");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Paco1234$");

            builder.Entity<IdentityUser>().HasData(users);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = users[0].Id,
                    RoleId = roles.Single(r => r.Name == IUserRoles.ADMIN).Id
                },
                new IdentityUserRole<string>
                {
                    UserId = users[1].Id,
                    RoleId = roles.Single(r => r.Name == IUserRoles.STAFF).Id
                },
                new IdentityUserRole<string>
                {
                    UserId = users[2].Id,
                    RoleId = roles.Single(r => r.Name == IUserRoles.CLIENTE).Id
                }
            );

            List<Producto> productos = new List<Producto>()
            {
                new Producto {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Camiseta Básica Algodón",
                    Descripcion = "Camiseta de manga corta, 100% algodón suave.",
                    Precio = 19.99m,
                    Stock = 100,
                    FechaCreacion = DateTime.Now.AddDays(-30),
                    FechaActualizacion = DateTime.Now },
                new Producto {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Pantalón Vaquero Recto",
                    Descripcion = "Pantalón vaquero clásico de corte recto.",
                    Precio = 49.99m,
                    Stock = 50,
                    FechaCreacion = DateTime.Now.AddDays(-60),
                    FechaActualizacion = DateTime.Now
                },
                new Producto {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Zapatillas Deportivas Urbanas",
                    Descripcion = "Zapatillas cómodas y con estilo para el día a día.",
                    Precio = 79.99m,
                    Stock = 75,
                    FechaCreacion = DateTime.Now.AddDays(-45),
                    FechaActualizacion = DateTime.Now
                },
                new Producto {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Bolso de Cuero Grande",
                    Descripcion = "Bolso de cuero genuino con múltiples compartimentos.",
                    Precio = 129.99m,
                    Stock = 20,
                    FechaCreacion = DateTime.Now.AddDays(-90),
                    FechaActualizacion = DateTime.Now
                },
                new Producto {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Gafas de Sol Polarizadas",
                    Descripcion = "Gafas de sol con lentes polarizadas para una visión clara.",
                    Precio = 59.99m,
                    Stock = 60,
                    FechaCreacion = DateTime.Now.AddDays(-20),
                    FechaActualizacion = DateTime.Now
                },
                new Producto {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Libro 'Aventuras Épicas'",
                    Descripcion = "Una emocionante novela de fantasía y aventuras.",
                    Precio = 12.50m,
                    Stock = 150,
                    FechaCreacion = DateTime.Now.AddDays(-15),
                    FechaActualizacion = DateTime.Now
                },
                new Producto {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Taza de Cerámica Decorada",
                    Descripcion = "Taza de cerámica de alta calidad con diseño único.",
                    Precio = 8.99m,
                    Stock = 200,
                    FechaCreacion = DateTime.Now.AddDays(-7),
                    FechaActualizacion = DateTime.Now
                },
                new Producto {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Funda Protectora para Smartphone",
                    Descripcion = "Funda resistente para proteger tu teléfono de golpes y arañazos.",
                    Precio = 24.99m, Stock = 120,
                    FechaCreacion = DateTime.Now.AddDays(-35),
                    FechaActualizacion = DateTime.Now
                },
                new Producto {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Reloj de Pulsera Clásico",
                    Descripcion = "Reloj elegante con correa de cuero y movimiento de cuarzo.",
                    Precio = 99.99m,
                    Stock = 30,
                    FechaCreacion = DateTime.Now.AddDays(-50),
                    FechaActualizacion = DateTime.Now
                },
                new Producto {
                    IdProducto = Guid.NewGuid(),
                    Nombre = "Auriculares Inalámbricos Bluetooth",
                    Descripcion = "Auriculares con conexión Bluetooth y sonido de alta fidelidad.",
                    Precio = 69.99m,
                    Stock = 80,
                    FechaCreacion = DateTime.Now.AddDays(-25),
                    FechaActualizacion = DateTime.Now
                }
            };

            builder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Precio).HasPrecision(18, 2);
                entity.HasData(productos);
            });

            List<Categoria> categorias = new List<Categoria>()
            {
                new Categoria { IdCategoria = Guid.NewGuid(), Nombre = "Ropa" },
                new Categoria { IdCategoria = Guid.NewGuid(), Nombre = "Calzado" },
                new Categoria { IdCategoria = Guid.NewGuid(), Nombre = "Accesorios" },
                new Categoria { IdCategoria = Guid.NewGuid(), Nombre = "Hogar" },
                new Categoria { IdCategoria = Guid.NewGuid(), Nombre = "Libros" },
                new Categoria { IdCategoria = Guid.NewGuid(), Nombre = "Tecnología" },
                new Categoria { IdCategoria = Guid.NewGuid(), Nombre = "Electrónica" },
                new Categoria { IdCategoria = Guid.NewGuid(), Nombre = "Deportes" },
                new Categoria { IdCategoria = Guid.NewGuid(), Nombre = "Belleza" },
                new Categoria { IdCategoria = Guid.NewGuid(), Nombre = "Joyería" }
            };

            builder.Entity<Categoria>().HasData(categorias);

            builder.Entity<ProductoCategoria>().HasData(
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Camiseta Básica Algodón").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Ropa").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Pantalón Vaquero Recto").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Ropa").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Zapatillas Deportivas Urbanas").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Calzado").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Zapatillas Deportivas Urbanas").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Deportes").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Bolso de Cuero Grande").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Accesorios").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Bolso de Cuero Grande").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Belleza").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Gafas de Sol Polarizadas").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Accesorios").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Libro 'Aventuras Épicas'").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Libros").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Taza de Cerámica Decorada").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Hogar").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Funda Protectora para Smartphone").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Tecnología").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Funda Protectora para Smartphone").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Electrónica").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Reloj de Pulsera Clásico").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Accesorios").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Reloj de Pulsera Clásico").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Joyería").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Auriculares Inalámbricos Bluetooth").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Tecnología").IdCategoria
                },
                new ProductoCategoria {
                    IdProductoCategoria = Guid.NewGuid(),
                    IdProducto = productos.First(p => p.Nombre == "Auriculares Inalámbricos Bluetooth").IdProducto,
                    IdCategoria = categorias.First(c => c.Nombre == "Electrónica").IdCategoria
                }
            );

            var clientePacoId = users.Single(u => u.UserName == "paco.montoro").Id;

            List<Direccion> direcciones = new List<Direccion>()
            {
                new Direccion
                {
                    IdDireccion = Guid.NewGuid(),
                    IdUsuario = clientePacoId,
                    Domicilio = "Avenida Siempreviva 742",
                    CodigoPostal = 28080,
                    Ciudad = "Madrid",
                    Provincia = "Madrid",
                    Pais = "España",
                    principal = true
                },
                new Direccion
                {
                    IdDireccion = Guid.NewGuid(),
                    IdUsuario = clientePacoId,
                    Domicilio = "Calle de la Piruleta 15",
                    CodigoPostal = 08001,
                    Ciudad = "Barcelona",
                    Provincia = "Barcelona",
                    Pais = "España",
                    principal = false
                }
            };

            builder.Entity<Direccion>().HasData(direcciones);

            Direccion direccionPaco = direcciones.OrderBy(o => o.principal).Single(d =>
                d.IdUsuario == clientePacoId && d.principal == true
            );

            List<Pedido> pedidos = new List<Pedido>()
            {
                new Pedido
                {
                    IdPedido = Guid.NewGuid(),
                    Numero = 1,
                    IdUsuario = clientePacoId,
                    IdDireccion = direccionPaco.IdDireccion,
                    FechaCreacion = DateTime.Now.AddDays(-1),
                    Estado = IEstadosPedido.PENDIENTE,
                    Total = 45.99m
                },
                new Pedido
                {
                    IdPedido = Guid.NewGuid(),
                    Numero = 2,
                    IdUsuario = clientePacoId,
                    IdDireccion = direccionPaco.IdDireccion,
                    FechaCreacion = DateTime.Now.AddDays(-5),
                    Estado = IEstadosPedido.ENVIADO,
                    Total = 89.50m
                }
            };

            builder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.Total).HasPrecision(18, 2);
                entity.HasData(pedidos);
            });

            var pedido1 = pedidos.First(p => p.Numero == 1 && p.IdUsuario == clientePacoId);
            var pedido2 = pedidos.First(p => p.Numero == 2 && p.IdUsuario == clientePacoId);

            var camiseta = productos.First(p => p.Nombre == "Camiseta Básica Algodón");
            var pantalon = productos.First(p => p.Nombre == "Pantalón Vaquero Recto");
            var libro = productos.First(p => p.Nombre == "Libro 'Aventuras Épicas'");
            var auriculares = productos.First(p => p.Nombre == "Auriculares Inalámbricos Bluetooth");

            List<DetallesPedidos> detallesPedidos = new List<DetallesPedidos>()
            {
                new DetallesPedidos
                {
                    IdDetalle = Guid.NewGuid(),
                    IdPedido = pedido1.IdPedido,
                    IdProducto = camiseta.IdProducto,
                    Cantidad = 2,
                    PrecioUnitario = camiseta.Precio,
                    Subtotal = camiseta.Precio * 2
                },
                new DetallesPedidos
                {
                    IdDetalle = Guid.NewGuid(),
                    IdPedido = pedido1.IdPedido,
                    IdProducto = libro.IdProducto,
                    Cantidad = 1,
                    PrecioUnitario = libro.Precio,
                    Subtotal = libro.Precio
                },
                new DetallesPedidos
                {
                    IdDetalle = Guid.NewGuid(),
                    IdPedido = pedido2.IdPedido,
                    IdProducto = pantalon.IdProducto,
                    Cantidad = 1,
                    PrecioUnitario = pantalon.Precio,
                    Subtotal = pantalon.Precio
                },
                new DetallesPedidos
                {
                    IdDetalle = Guid.NewGuid(),
                    IdPedido = pedido2.IdPedido,
                    IdProducto = auriculares.IdProducto,
                    Cantidad = 1,
                    PrecioUnitario = auriculares.Precio,
                    Subtotal = auriculares.Precio
                }
            };

            builder.Entity<DetallesPedidos>(entity =>
            {
                entity.Property(e => e.Subtotal).HasPrecision(18, 2);
                entity.Property(e => e.PrecioUnitario).HasPrecision(18, 2);
                entity.HasData(detallesPedidos);
            });

            builder.Entity<Carrito>(entity =>
            {
                entity.Property(e => e.Total).HasPrecision(18, 2);
            });

            builder.Entity<ItemCarrito>(entity =>
            {
                entity.Property(e => e.PrecioUnitario).HasPrecision(18, 2);
                entity.Property(e => e.Subtotal).HasPrecision(18, 2);
            });
        }
    }
}

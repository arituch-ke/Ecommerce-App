using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Ecommerce.Server.Entites
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<SKU> SKUs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.SKUs)
                .WithOne()
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Name = "Beoplay A1",
                   Description = "High-quality portable speaker",
                   ImageUrl = "https://cdn5.425degree.com/media/amasty/webp/wysiwyg/2020/07/Air_by_MPOW_X51J/BnO_A1_Gen2/Beosound_a1_black_hero_jpg.webp",
                   OriginalPrice = 57.00m,
                   DiscountedPrice = 39.00m,
                   Rating = 5,
                   RatingCount = 10, // Example rating count
                   Vendor = "Bang & Olufsen",
                   CreatedAt = DateTime.Now,
                   UpdatedAt = DateTime.Now,
                   Category = "Electronics"
               },
                new Product
                {
                    Id = 2,
                    Name = "Artisan Chair",
                    Description = "Comfortable and stylish chair",
                    ImageUrl = "https://artisan-production.ams3.cdn.digitaloceanspaces.com/neva_chair_inspiration_8_6dd1b35090.png",
                    OriginalPrice = 48.00m,
                    DiscountedPrice = 40.00m,
                    Rating = 4,
                    RatingCount = 8, // Example rating count
                    Vendor = "Artisan",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Category = "Furniture"
                },
                new Product
                {
                    Id = 3,
                    Name = "Hanging Egg Chair",
                    Description = "Elegant and relaxing hanging chair",
                    ImageUrl = "https://sika-design.com/cdn/shop/products/Hanging_Egg_stand_4957_1200x.jpg?v=1648003559",
                    OriginalPrice = 99.00m,
                    DiscountedPrice = 89.00m,
                    Rating = 5,
                    RatingCount = 12, // Example rating count
                    Vendor = "Egg Chairs",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Category = "Furniture"
                },
                new Product
                {
                    Id = 4,
                    Name = "Hubert Pendant Lamp",
                    Description = "Modern pendant lamp with sleek design",
                    ImageUrl = "https://www.macomaitaly.com/33163-large_default/hubert-pendant-lamp-audo-.jpg",
                    OriginalPrice = 149.00m,
                    DiscountedPrice = 140.00m,
                    Rating = 4,
                    RatingCount = 6, // Example rating count
                    Vendor = "Lighting",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Category = "Lighting"
                },
                new Product
                {
                    Id = 5,
                    Name = "Iconic Rocking Horse",
                    Description = "Classic rocking horse for children",
                    ImageUrl = "https://www.designboom.com/wp-content/dbsub/401760/2017-08-17/img_1_1502954593_09c46de59d5651a30e2240ed15335b13.jpg",
                    OriginalPrice = 150.00m,
                    DiscountedPrice = 135.00m,
                    Rating = 5,
                    RatingCount = 5, // Example rating count
                    Vendor = "Toys",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Category = "Toys"
                },
                new Product
                {
                    Id = 6,
                    Name = "League Stack Chair",
                    Description = "Stackable and versatile chair",
                    ImageUrl = "https://www.eustischair.com/wp-content/uploads/2019/04/Ivy-League-Stackable-M.jpg",
                    OriginalPrice = 290.00m,
                    DiscountedPrice = 250.00m,
                    Rating = 4,
                    RatingCount = 9, // Example rating count
                    Vendor = "League",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Category = "Furniture"
                },
                new Product
                {
                    Id = 7,
                    Name = "Laundry Baskets",
                    Description = "Durable and stylish laundry baskets",
                    ImageUrl = "https://www.ikea.com/th/en/images/products/tolkning-laundry-basket-handmade-willow__1098731_pe865503_s5.jpg?f=s",
                    OriginalPrice = 45.00m,
                    DiscountedPrice = 40.00m,
                    Rating = 4,
                    RatingCount = 7, // Example rating count
                    Vendor = "Home Essentials",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Category = "Home Essentials"
                },
                new Product
                {
                    Id = 8,
                    Name = "Mug Table Lamp",
                    Description = "Unique table lamp with mug design",
                    ImageUrl = "https://www.midj.com/images/uploads/products/_xl/mug-table-midj.jpg",
                    OriginalPrice = 89.00m,
                    DiscountedPrice = 79.00m,
                    Rating = 5,
                    RatingCount = 11, // Example rating count
                    Vendor = "Lighting",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Category = "Lighting"
                }

             );
            modelBuilder.Entity<SKU>().HasData(
                new SKU { Id = 1, Code = "B&O-A1-001", InStock = true, ProductId = 1 },
                new SKU { Id = 2, Code = "B&O-A1-002", InStock = false, ProductId = 1 },
                new SKU { Id = 3, Code = "ART-CHAIR-001", InStock = true, ProductId = 2 },
                new SKU { Id = 4, Code = "EGG-CHAIR-001", InStock = true, ProductId = 3 },
                new SKU { Id = 5, Code = "EGG-CHAIR-002", InStock = true, ProductId = 3 },
                new SKU { Id = 6, Code = "HUB-LAMP-001", InStock = false, ProductId = 4 },
                new SKU { Id = 7, Code = "TOY-HORSE-001", InStock = true, ProductId = 5 },
                new SKU { Id = 8, Code = "LEA-CHAIR-001", InStock = true, ProductId = 6 },
                new SKU { Id = 9, Code = "HOME-BASKET-001", InStock = true, ProductId = 7 },
                new SKU { Id = 10, Code = "LAMP-MUG-001", InStock = true, ProductId = 8 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

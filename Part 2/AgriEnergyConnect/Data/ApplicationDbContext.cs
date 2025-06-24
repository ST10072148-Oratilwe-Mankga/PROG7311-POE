using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect.Models;

namespace AgriEnergyConnect.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Farmer)
                .WithMany(f => f.Products)
                .HasForeignKey(p => p.FarmerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Farmer)
                .WithMany()
                .HasForeignKey(u => u.FarmerId)
                .OnDelete(DeleteBehavior.SetNull);

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Farmers
            modelBuilder.Entity<Farmer>().HasData(
                new Farmer { Id = 1, Name = "John Smith", Email = "john.smith@email.com", PhoneNumber = "0821234567", FarmLocation = "Mpumalanga", FarmType = "Maize", Description = "Large scale maize farmer", RegistrationDate = DateTime.Now.AddDays(-30) },
                new Farmer { Id = 2, Name = "Sarah Johnson", Email = "sarah.johnson@email.com", PhoneNumber = "0832345678", FarmLocation = "Free State", FarmType = "Wheat", Description = "Wheat and barley producer", RegistrationDate = DateTime.Now.AddDays(-25) },
                new Farmer { Id = 3, Name = "Michael Brown", Email = "michael.brown@email.com", PhoneNumber = "0843456789", FarmLocation = "Western Cape", FarmType = "Vineyards", Description = "Wine grape producer", RegistrationDate = DateTime.Now.AddDays(-20) }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Yellow Maize", Category = "Grains", ProductionDate = DateTime.Now.AddDays(-10), Description = "High quality yellow maize", Price = 3500.00m, Quantity = 100, Unit = "tons", FarmerId = 1 },
                new Product { Id = 2, Name = "White Maize", Category = "Grains", ProductionDate = DateTime.Now.AddDays(-8), Description = "Premium white maize", Price = 3800.00m, Quantity = 75, Unit = "tons", FarmerId = 1 },
                new Product { Id = 3, Name = "Spring Wheat", Category = "Grains", ProductionDate = DateTime.Now.AddDays(-15), Description = "Organic spring wheat", Price = 4200.00m, Quantity = 50, Unit = "tons", FarmerId = 2 },
                new Product { Id = 4, Name = "Barley", Category = "Grains", ProductionDate = DateTime.Now.AddDays(-12), Description = "Malting barley", Price = 3900.00m, Quantity = 60, Unit = "tons", FarmerId = 2 },
                new Product { Id = 5, Name = "Cabernet Sauvignon Grapes", Category = "Fruits", ProductionDate = DateTime.Now.AddDays(-5), Description = "Premium wine grapes", Price = 15000.00m, Quantity = 20, Unit = "tons", FarmerId = 3 }
            );

            // Seed Users (password: "password123" - in production, use proper hashing)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "farmer1", Email = "john.smith@email.com", PasswordHash = "password123", Role = "Farmer", FarmerId = 1 },
                new User { Id = 2, Username = "farmer2", Email = "sarah.johnson@email.com", PasswordHash = "password123", Role = "Farmer", FarmerId = 2 },
                new User { Id = 3, Username = "farmer3", Email = "michael.brown@email.com", PasswordHash = "password123", Role = "Farmer", FarmerId = 3 },
                new User { Id = 4, Username = "employee1", Email = "employee@agrienergy.com", PasswordHash = "password123", Role = "Employee" }
            );
        }
    }
} 
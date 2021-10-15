using CakeManagements.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeManagements.Models.Cake;

namespace CakeManagements.Contexts
{
    public class CakeManagementDBContext : DbContext
    {
        public CakeManagementDBContext (DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cake> Cakes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedingCategory(modelBuilder);
            SeedingCake(modelBuilder);
        }
        private void SeedingCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Cake 1"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Cake 2"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Cake 3"
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Cake 4"
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Cake 5"
                }
                );
        }
        private void SeedingCake(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cake>().HasData(
                new Cake()
                {
                    CakeId = 1,
                    CakeName = "cake 12",
                    Ingredient = "bột_đường",
                    Expiry = "3 ngày",
                    DateOfManufacture = "03-10-2021",
                    Price = 12,
                    Deleted = false,
                    CategoryId = 1
                }
                );
        }
        public DbSet<CakeManagements.Models.Cake.Edit> Edit { get; set; }
        public DbSet<CakeManagements.Models.Cake.Detail> Detail { get; set; }
    }
}

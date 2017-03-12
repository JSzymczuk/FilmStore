using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FilmStore.Models
{
    public class FilmStoreDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }

        public FilmStoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static FilmStoreDbContext Create()
        {
            return new FilmStoreDbContext();
        }
    }
}
using JewelryStore.Domain.Entities.Jewelry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JawelryStore.Persistance.EntityFrameworks
{
    public class JewelryStoreContext:DbContext
    {
        public JewelryStoreContext(DbContextOptions<JewelryStoreContext> optionsBuilder)
            : base(optionsBuilder)
        {
            
        }

        public DbSet<Users> Userss =>this.Set<Users>();
        public DbSet<UsersRole> UsersRoles =>this.Set<UsersRole>();
        public DbSet<UserDetail> UserDetails => this.Set<UserDetail>();
        public DbSet<Role> Roles => this.Set<Role>();
        public DbSet<Product> Products => this.Set<Product>();
        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<Images> Imagess => this.Set<Images>();
        public DbSet<Review> Reviews => this.Set<Review>();
        public DbSet<Designers> Designerss => this.Set<Designers>();
        public DbSet<SubCategory> SubCategories => this.Set<SubCategory>();
        public DbSet<CartItems> CartItemss => this.Set<CartItems>();
        public DbSet<ProductDetail> ProductDetails => this.Set<ProductDetail>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                new Category { id = 1, Value = "Men" },
                new Category { id = 2, Value = "Women" },
                new Category { id = 3, Value = "Kids" },
                new Category { id = 4, Value = "Beauty" },
                new Category { id = 5, Value = "Jewelry" },
                new Category { id = 6, Value = "Designers" }
               
                );

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }

    }
}

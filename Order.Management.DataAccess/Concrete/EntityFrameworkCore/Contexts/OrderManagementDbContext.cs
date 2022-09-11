using Microsoft.EntityFrameworkCore;
using Order.Management.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class OrderManagementDbContext : DbContext
    {
        // DbContext class'in icine database tablolarınını tanımladık.
        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Orders>()
                        .HasOne<Customer>(a => a.Customer)
                        .WithMany(b => b.Order)
                        .HasForeignKey(b => b.CustomerId);
            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });
            modelBuilder.Entity<OrderProduct>()
                        .HasOne<Orders>(a => a.Order)
                        .WithMany(b => b.OrderProducts)
                        .HasForeignKey(b => b.OrderId);
           modelBuilder.Entity<OrderProduct>()
                        .HasOne<Product>(a => a.Product)
                        .WithMany(b => b.OrderProducts)
                        .HasForeignKey(b => b.ProductId);
        }

    }
}

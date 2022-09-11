using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Management.Core.Concrete;
using Order.Management.Core.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.DataAccess.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                Barcode = "123456780",
                Quantity = 1,
                Description = "Tablet",
                Price = 1000,
                CreationDate = DateTime.Now,
                IsActive = Active.Active,
               
            }, new Product
            {
                Id = 2,
                Barcode = "123456781",
                Quantity = 1,
                Description = "Bilgisayar",
                Price = 9000,
                CreationDate = DateTime.Now,
                IsActive = Active.Active,
            
            }, new Product
            {
                Id = 3,
                Barcode = "123456782",
                Quantity = 1,
                Description = "Telefon",
                Price = 4000,
                CreationDate = DateTime.Now,
                IsActive = Active.Active,
                
            },
             new Product
             {
                 Id = 4,
                 Barcode = "123456780",
                 Quantity = 1,
                 Description = "Tablet",
                 Price = 1000,
                 CreationDate = DateTime.Now,
                 IsActive = Active.Active,
                

             }, new Product
             {
                 Id = 5,
                 Barcode = "123456781",
                 Quantity = 1,
                 Description = "Bilgisayar",
                 Price = 9000,
                 CreationDate = DateTime.Now,
                 IsActive = Active.Active,
                
             }, new Product
             {
                 Id = 6,
                 Barcode = "123456782",
                 Quantity = 1,
                 Description = "Telefon",
                 Price = 4000,
                 CreationDate = DateTime.Now,
                 IsActive = Active.Active,
                
             });
        }
    }
}

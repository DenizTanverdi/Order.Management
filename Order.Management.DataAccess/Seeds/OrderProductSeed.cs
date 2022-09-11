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
    internal class OrderProductSeed : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasData(new OrderProduct
            {
               Id = 1,
                OrderId = 1,
                ProductId = 1,
                Quantity = 1,
                CreationDate = DateTime.Now,
                IsActive = Active.Active,

            }, new OrderProduct
            {
                Id = 2,
                OrderId = 1,
                ProductId = 2,
                Quantity = 2,
                CreationDate = DateTime.Now,
                IsActive = Active.Active,
            }, new OrderProduct
            {
                Id = 3,
                OrderId = 1,
                ProductId = 3,
                Quantity = 3,
                CreationDate = DateTime.Now,
                IsActive = Active.Active,

            },
             new OrderProduct
             {
                 Id = 4,
                 OrderId = 2,
                 ProductId = 1,
                 Quantity= 1,
                 CreationDate = DateTime.Now,
                 IsActive = Active.Active,


             }, new OrderProduct
             {
                 Id = 5,
                 OrderId = 2,
                 ProductId = 2,
                 Quantity=1,
                 CreationDate = DateTime.Now,
                 IsActive = Active.Active,

             }, new OrderProduct
             {
                 Id = 6,
                 OrderId = 2,
                 ProductId = 3,
                 Quantity=2,
                 CreationDate = DateTime.Now,
                 IsActive = Active.Active,

             });
        }
    }
}

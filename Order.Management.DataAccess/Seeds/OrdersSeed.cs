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
    public class OrdersSeed : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasData(new Orders
            {
                Id = 1,
                CustomerId = 1,
                OrderAddress="Sultangazi",
                CreationDate = DateTime.Now,
                IsActive = Active.Active
            },
            new Orders
            {
                Id = 2,
                CustomerId = 2,
                OrderAddress = "Arnavutköy",
                CreationDate = DateTime.Now,
                IsActive = Active.Active
            });
        }
    }
}

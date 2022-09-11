using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Management.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Order.Management.DataAccess.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {

            builder.HasKey(x => new { x.OrderId, x.ProductId });
            builder.HasOne(x => x.Order).WithMany(x => x.OrderProducts).HasForeignKey(b => b.OrderId);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderProducts).HasForeignKey(b => b.ProductId);

        }
    }
}

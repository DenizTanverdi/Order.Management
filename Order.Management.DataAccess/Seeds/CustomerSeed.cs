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
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
            {
                Id = 1,
                Name = "Deniz Tanriverdi",
                Address = "Arnavutköy",
                CreationDate = DateTime.Now,
                IsActive = Active.Active,
            },
                new Customer
            {
                Id = 2,
                Name = "Ali Tanriverdi",
                Address = "Esenler",
                CreationDate = DateTime.Now,
                IsActive = Active.Active,
            });
        }
    }
}

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
    public class ApplicationUserSeed : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
               new ApplicationUser
               {
                   Id = 1,
                   Username = "admin",
                 Password = "Q1w2E3s",
                   CreationDate = DateTime.Now,
                   IsActive = Active.Active,
               });
        }
    }
}

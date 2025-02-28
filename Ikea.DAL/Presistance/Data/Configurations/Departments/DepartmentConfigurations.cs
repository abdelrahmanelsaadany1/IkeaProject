using Ikea.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.DAL.Presistance.Data.Configurations.Departments
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        

            public void Configure(EntityTypeBuilder<Department> builder)
            {

                builder.Property(x => x.Id).UseIdentityColumn(10, 10);
                builder.Property(x => x.Name).HasColumnType("varchar(50)").IsRequired();
                builder.Property(x => x.Code).HasColumnType("varchar(50)").IsRequired();
                builder.Property(x => x.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
                builder.Property(x => x.LastModificationOn).HasComputedColumnSql("GETDATE()");


            }
        
    }
}

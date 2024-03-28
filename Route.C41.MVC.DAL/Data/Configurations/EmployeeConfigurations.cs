using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.C41.MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.MVC.DAL.Data.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasMaxLength(50).IsRequired().HasColumnType("varchar");
            builder.Property(E => E.Address).HasMaxLength(67).IsRequired(false).HasColumnType("varchar");
            builder.Property(E => E.Salary).HasColumnType("decimal(9,2)").IsRequired();
            builder.Property(E => E.Email).HasColumnType("varchar(max)").IsRequired(false);
            builder.Property(E=> E.Phone).IsRequired().HasColumnType("varchar").HasMaxLength(20);

            builder.Property(E => E.Gender).HasConversion(
                E => E.ToString(),
                E => (Gender)Enum.Parse(typeof(Gender), E.ToString())
                ).IsRequired().HasColumnType("varchar").HasMaxLength(6);

            builder.Property(E => E.EmployeeType).HasConversion(
                E=> E.ToString(),
                E=> (EmployeeType)Enum.Parse(typeof(EmployeeType), E.ToString())  
                ).HasMaxLength(9).HasColumnType("varchar").IsRequired();

            builder.Property(E=>E.HiringDate).IsRequired();
            builder.Property(E=> E.CreationDate).HasDefaultValueSql("GETDATE()");

        }
    }
}

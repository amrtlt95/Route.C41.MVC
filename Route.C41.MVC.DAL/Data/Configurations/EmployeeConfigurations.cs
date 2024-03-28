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
            builder.Property(E => E.Gender).HasConversion(
                gender => gender.ToString(),
                gender => (Gender)Enum.Parse(typeof(Gender), gender.ToString())
                );

            builder.Property(E => E.EmployeeType).HasConversion(
                employeeType => employeeType.ToString(),
                employeeType => (EmployeeType)Enum.Parse(typeof(EmployeeType), employeeType.ToString())
                );

            builder.Property(E => E.Name).HasColumnType("varchar").IsRequired();

            builder.Property(E => E.Age).IsRequired(false);

            builder.Property(E => E.Salary).HasColumnType("decimal(9,2)");

            builder.Property(E => E.CreationDate).HasDefaultValueSql("GETDATE()");

            builder.Property(E => E.Gender).HasColumnType("varchar").HasMaxLength(6);

            builder.Property(E => E.EmployeeType).HasColumnType("varchar").HasMaxLength(8);

            builder.Property(E => E.Address).HasColumnType("varchar");
            builder.Property(E => E.Email).HasColumnType("varchar");
            builder.Property(E => E.Phone).HasColumnType("varchar");



        }
    }
}

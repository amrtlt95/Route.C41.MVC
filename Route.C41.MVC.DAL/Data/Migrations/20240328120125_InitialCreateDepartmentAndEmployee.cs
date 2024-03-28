using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Route.C41.MVC.DAL.Data.Migrations
{
    public partial class InitialCreateDepartmentAndEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, computedColumnSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "varchar(67)", maxLength: 67, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "varchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    EmployeeType = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}

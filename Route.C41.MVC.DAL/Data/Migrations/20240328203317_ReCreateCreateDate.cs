using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Route.C41.MVC.DAL.Data.Migrations
{
    public partial class ReCreateCreateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Departments");
        }
    }
}

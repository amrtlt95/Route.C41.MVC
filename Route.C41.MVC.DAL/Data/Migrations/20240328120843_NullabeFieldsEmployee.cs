using Microsoft.EntityFrameworkCore.Migrations;

namespace Route.C41.MVC.DAL.Data.Migrations
{
    public partial class NullabeFieldsEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employee",
                type: "varchar(67)",
                maxLength: 67,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(67)",
                oldMaxLength: 67);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employee",
                type: "varchar(67)",
                maxLength: 67,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(67)",
                oldMaxLength: 67,
                oldNullable: true);
        }
    }
}

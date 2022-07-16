using Microsoft.EntityFrameworkCore.Migrations;

namespace dot_bioskop.Migrations
{
    public partial class DBinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "is_admin",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "bool");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "is_admin",
                table: "users",
                type: "bool",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

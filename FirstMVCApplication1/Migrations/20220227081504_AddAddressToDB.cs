using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMVCApplication1.Migrations
{
    public partial class AddAddressToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AddAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AddAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "AddAddresses");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AddAddresses");
        }
    }
}

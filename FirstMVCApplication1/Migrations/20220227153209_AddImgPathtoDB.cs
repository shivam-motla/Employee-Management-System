using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMVCApplication1.Migrations
{
    public partial class AddImgPathtoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgpath",
                table: "AddAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgpath",
                table: "AddAddresses");
        }
    }
}

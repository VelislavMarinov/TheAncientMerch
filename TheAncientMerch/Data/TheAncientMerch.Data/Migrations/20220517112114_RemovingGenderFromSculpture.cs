using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheAncientMerch.Data.Migrations
{
    public partial class RemovingGenderFromSculpture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "Sculptures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                table: "Sculptures",
                type: "bit",
                nullable: true);
        }
    }
}

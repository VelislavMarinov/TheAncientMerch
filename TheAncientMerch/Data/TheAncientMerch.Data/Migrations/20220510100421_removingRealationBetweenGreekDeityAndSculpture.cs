using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheAncientMerch.Data.Migrations
{
    public partial class removingRealationBetweenGreekDeityAndSculpture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sculptures_GreekDeities_GreekDeityId",
                table: "Sculptures");

            migrationBuilder.DropIndex(
                name: "IX_Sculptures_GreekDeityId",
                table: "Sculptures");

            migrationBuilder.DropColumn(
                name: "GreekDeityId",
                table: "Sculptures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GreekDeityId",
                table: "Sculptures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sculptures_GreekDeityId",
                table: "Sculptures",
                column: "GreekDeityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sculptures_GreekDeities_GreekDeityId",
                table: "Sculptures",
                column: "GreekDeityId",
                principalTable: "GreekDeities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheAncientMerch.Data.Migrations
{
    public partial class RemovingHomeDecorHomeMaterialAndIsGardenStatued : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeDecors");

            migrationBuilder.DropTable(
                name: "HomeDecorMaterials");

            migrationBuilder.DropColumn(
                name: "IsGardenStatue",
                table: "Sculptures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGardenStatue",
                table: "Sculptures",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeDecorMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeDecorMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeDecors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Depth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HomeDecorType = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weigth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeDecors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeDecors_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HomeDecors_HomeDecorMaterials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "HomeDecorMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeDecors_AddedByUserId",
                table: "HomeDecors",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeDecors_IsDeleted",
                table: "HomeDecors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_HomeDecors_MaterialId",
                table: "HomeDecors",
                column: "MaterialId");
        }
    }
}

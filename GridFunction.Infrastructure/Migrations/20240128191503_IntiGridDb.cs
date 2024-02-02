using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GridFunction.Infrastructure.Migrations
{
    public partial class IntiGridDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grids",
                columns: table => new
                {
                    GridId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GridName = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grids", x => x.GridId);
                });

            migrationBuilder.CreateTable(
                name: "GridDetails",
                columns: table => new
                {
                    GridDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    OtherDetails = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    GridId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GridDetails", x => x.GridDetailId);
                    table.ForeignKey(
                        name: "FK_GridDetails_Grids_GridId",
                        column: x => x.GridId,
                        principalTable: "Grids",
                        principalColumn: "GridId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GridRegions",
                columns: table => new
                {
                    GridRegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GridId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GridRegions", x => x.GridRegionId);
                    table.ForeignKey(
                        name: "FK_GridRegions_Grids_GridId",
                        column: x => x.GridId,
                        principalTable: "Grids",
                        principalColumn: "GridId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GridNodes",
                columns: table => new
                {
                    GridNodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NodeName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    GridRegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GridNodes", x => x.GridNodeId);
                    table.ForeignKey(
                        name: "FK_GridNodes_GridRegions_GridRegionId",
                        column: x => x.GridRegionId,
                        principalTable: "GridRegions",
                        principalColumn: "GridRegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    MeasureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CollectedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Measurement = table.Column<int>(type: "int", nullable: false),
                    GridNodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.MeasureId);
                    table.ForeignKey(
                        name: "FK_Measures_GridNodes_GridNodeId",
                        column: x => x.GridNodeId,
                        principalTable: "GridNodes",
                        principalColumn: "GridNodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Grids",
                columns: new[] { "GridId", "GridName" },
                values: new object[] { 1, "Grid1" });

            migrationBuilder.InsertData(
                table: "Grids",
                columns: new[] { "GridId", "GridName" },
                values: new object[] { 2, "Grid2" });

            migrationBuilder.InsertData(
                table: "Grids",
                columns: new[] { "GridId", "GridName" },
                values: new object[] { 3, "Grid3" });

            migrationBuilder.InsertData(
                table: "GridRegions",
                columns: new[] { "GridRegionId", "GridId", "RegionName" },
                values: new object[,]
                {
                    { 1, 1, "Region1" },
                    { 2, 1, "Region2" },
                    { 3, 1, "Region3" },
                    { 4, 2, "Region1" },
                    { 5, 2, "Region2" },
                    { 6, 2, "Region3" },
                    { 7, 3, "Region1" },
                    { 8, 3, "Region2" },
                    { 9, 3, "Region3" }
                });

            migrationBuilder.InsertData(
                table: "GridNodes",
                columns: new[] { "GridNodeId", "GridRegionId", "NodeName" },
                values: new object[,]
                {
                    { 1, 1, "Node1" },
                    { 2, 1, "Node2" },
                    { 3, 1, "Node3" },
                    { 4, 2, "Node1" },
                    { 5, 2, "Node2" },
                    { 6, 2, "Node3" },
                    { 7, 3, "Node1" },
                    { 8, 3, "Node2" },
                    { 9, 3, "Node3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GridDetails_GridId",
                table: "GridDetails",
                column: "GridId");

            migrationBuilder.CreateIndex(
                name: "IX_GridNodes_GridRegionId",
                table: "GridNodes",
                column: "GridRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_GridRegions_GridId",
                table: "GridRegions",
                column: "GridId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_GridNodeId",
                table: "Measures",
                column: "GridNodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GridDetails");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "GridNodes");

            migrationBuilder.DropTable(
                name: "GridRegions");

            migrationBuilder.DropTable(
                name: "Grids");
        }
    }
}

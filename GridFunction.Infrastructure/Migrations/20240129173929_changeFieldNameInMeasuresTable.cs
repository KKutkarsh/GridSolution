using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GridFunction.Infrastructure.Migrations
{
    public partial class changeFieldNameInMeasuresTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsertedAt",
                table: "Measures",
                newName: "Timespan");

            migrationBuilder.RenameColumn(
                name: "CollectedTime",
                table: "Measures",
                newName: "CollectedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timespan",
                table: "Measures",
                newName: "InsertedAt");

            migrationBuilder.RenameColumn(
                name: "CollectedAt",
                table: "Measures",
                newName: "CollectedTime");
        }
    }
}

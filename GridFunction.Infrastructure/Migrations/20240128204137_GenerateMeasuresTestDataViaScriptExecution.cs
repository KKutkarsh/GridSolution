using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GridFunction.Infrastructure.Migrations
{
    public partial class GenerateMeasuresTestDataViaScriptExecution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine("Assets/Scripts/MeasureSampleDataGenerationScript.Sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

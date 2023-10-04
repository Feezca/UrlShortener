using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Migrations
{
    public partial class UrlDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NormalUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ShortUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "NormalUrl", "ShortUrl" },
                values: new object[] { 1, "mercadolibre.com", "..." });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "NormalUrl", "ShortUrl" },
                values: new object[] { 2, "locoarts.com", "..." });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "NormalUrl", "ShortUrl" },
                values: new object[] { 3, "netmentor.com", "..." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}

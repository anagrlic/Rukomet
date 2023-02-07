using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PINProject.Data.Migrations
{
    public partial class Klubovi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klub",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeKluba = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradKluba = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTrofeja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klub", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klub");
        }
    }
}

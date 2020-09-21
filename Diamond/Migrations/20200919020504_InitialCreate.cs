using Microsoft.EntityFrameworkCore.Migrations;

namespace Diamond.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prodotto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    prezzo = table.Column<string>(nullable: true),
                    quantita = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reparto",
                columns: table => new
                {
                    repartoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reparto", x => x.repartoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prodotto");

            migrationBuilder.DropTable(
                name: "Reparto");
        }
    }
}

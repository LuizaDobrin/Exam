using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamProj.Migrations
{
    public partial class AddPachetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pachete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaraOrigine = table.Column<string>(nullable: true),
                    Expeditor = table.Column<string>(nullable: true),
                    TaraDestinatie = table.Column<string>(nullable: true),
                    Destinatar = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    CodTracking = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pachete", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pachete");
        }
    }
}

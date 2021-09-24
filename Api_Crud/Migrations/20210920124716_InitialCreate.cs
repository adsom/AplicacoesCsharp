using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Crud.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medidores",
                columns: table => new
                {
                    MedidorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedidorTipo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MedidorStatus = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    MedidorConsumo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidores", x => x.MedidorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medidores");
        }
    }
}

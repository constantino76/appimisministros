using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppiMinistros.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbOferente",
                columns: table => new
                {
                    OferenteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FechaNacimiento = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbOferente", x => x.OferenteId);
                });

            migrationBuilder.CreateTable(
                name: "TbExpLaboral",
                columns: table => new
                {
                    Idtrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Empresa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Anio_inicio = table.Column<int>(type: "int", nullable: false),
                    Anio_fin = table.Column<int>(type: "int", nullable: false),
                    OferenteId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbExpLaboral", x => x.Idtrabajo);
                    table.ForeignKey(
                        name: "FK_TbExpLaboral_TbOferente_OferenteId",
                        column: x => x.OferenteId,
                        principalTable: "TbOferente",
                        principalColumn: "OferenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbtitulos",
                columns: table => new
                {
                    TituloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradoAcademico = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CentroUniversitario = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Anio_titulo = table.Column<int>(type: "int", nullable: false),
                    OferenteId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbtitulos", x => x.TituloId);
                    table.ForeignKey(
                        name: "FK_Tbtitulos_TbOferente_OferenteId",
                        column: x => x.OferenteId,
                        principalTable: "TbOferente",
                        principalColumn: "OferenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbExpLaboral_OferenteId",
                table: "TbExpLaboral",
                column: "OferenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbtitulos_OferenteId",
                table: "Tbtitulos",
                column: "OferenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbExpLaboral");

            migrationBuilder.DropTable(
                name: "Tbtitulos");

            migrationBuilder.DropTable(
                name: "TbOferente");
        }
    }
}

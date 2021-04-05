using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_end.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoIdentificacion",
                columns: table => new
                {
                    IdTipoIdentificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacion", x => x.IdTipoIdentificacion);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(30)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(30)", nullable: false),
                    IdTipoIdentificacion = table.Column<int>(type: "int", nullable: false),
                    NumeroIdentificacion = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(30)", nullable: false),
                    Correo = table.Column<string>(type: "varchar(30)", nullable: false),
                    TipoIdentificacionIdTipoIdentificacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoIdentificacion_TipoIdentificacionIdTipoIdentific~",
                        column: x => x.TipoIdentificacionIdTipoIdentificacion,
                        principalTable: "TipoIdentificacion",
                        principalColumn: "IdTipoIdentificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoIdentificacionIdTipoIdentificacion",
                table: "Usuario",
                column: "TipoIdentificacionIdTipoIdentificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoIdentificacion");
        }
    }
}

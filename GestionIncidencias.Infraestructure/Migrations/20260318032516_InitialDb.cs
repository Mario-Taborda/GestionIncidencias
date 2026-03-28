using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionIncidencias.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encargado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encargado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Solicitud = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIncidencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSolucion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Incidencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSolucion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdUsuario = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requerimiento = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DescripcionProblema = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ImagenBase64 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    FechaIncidencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prioridad = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTipoIncidencia = table.Column<int>(type: "int", nullable: true),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdTipoSolucion = table.Column<int>(type: "int", nullable: true),
                    DescripcionSolucion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UsuarioFuente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoFuente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidencia_Estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidencia_TipoIncidencia_IdTipoIncidencia",
                        column: x => x.IdTipoIncidencia,
                        principalTable: "TipoIncidencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidencia_TipoSolucion_IdTipoSolucion",
                        column: x => x.IdTipoSolucion,
                        principalTable: "TipoSolucion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incidencia_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlujoIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    IdEncargado = table.Column<int>(type: "int", nullable: true),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdIncidencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlujoIncidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlujoIncidencia_Encargado_IdEncargado",
                        column: x => x.IdEncargado,
                        principalTable: "Encargado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlujoIncidencia_Estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlujoIncidencia_Incidencia_IdIncidencia",
                        column: x => x.IdIncidencia,
                        principalTable: "Incidencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlujoIncidencia_IdEncargado",
                table: "FlujoIncidencia",
                column: "IdEncargado");

            migrationBuilder.CreateIndex(
                name: "IX_FlujoIncidencia_IdEstado",
                table: "FlujoIncidencia",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_FlujoIncidencia_IdIncidencia",
                table: "FlujoIncidencia",
                column: "IdIncidencia");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencia_IdEstado",
                table: "Incidencia",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencia_IdTipoIncidencia",
                table: "Incidencia",
                column: "IdTipoIncidencia");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencia_IdTipoSolucion",
                table: "Incidencia",
                column: "IdTipoSolucion");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencia_IdUsuario",
                table: "Incidencia",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlujoIncidencia");

            migrationBuilder.DropTable(
                name: "Encargado");

            migrationBuilder.DropTable(
                name: "Incidencia");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "TipoIncidencia");

            migrationBuilder.DropTable(
                name: "TipoSolucion");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}

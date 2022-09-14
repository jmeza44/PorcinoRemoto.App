using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PorcinoRemoto.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    DireccionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.DireccionID);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasClinicas",
                columns: table => new
                {
                    HistoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaGeneracion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasClinicas", x => x.HistoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaID);
                    table.ForeignKey(
                        name: "FK_Personas_Direcciones_DireccionID",
                        column: x => x.DireccionID,
                        principalTable: "Direcciones",
                        principalColumn: "DireccionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonaID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Propietarios_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonaID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.TarjetaProfesional);
                    table.ForeignKey(
                        name: "FK_Veterinarios_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Porcinos",
                columns: table => new
                {
                    PorcinoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropietarioEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HistoriaClinicaHistoriaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porcinos", x => x.PorcinoID);
                    table.ForeignKey(
                        name: "FK_Porcinos_HistoriasClinicas_HistoriaClinicaHistoriaID",
                        column: x => x.HistoriaClinicaHistoriaID,
                        principalTable: "HistoriasClinicas",
                        principalColumn: "HistoriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Porcinos_Propietarios_PropietarioEmail",
                        column: x => x.PropietarioEmail,
                        principalTable: "Propietarios",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    VisitaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperatura = table.Column<double>(type: "float", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    EstadoAnimo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrecuenciaRespiratoria = table.Column<double>(type: "float", nullable: false),
                    FrecuenciaCardiaca = table.Column<double>(type: "float", nullable: false),
                    MedicamentosFormulados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PorcinoID = table.Column<int>(type: "int", nullable: false),
                    VeterinarioTarjetaProfesional = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.VisitaID);
                    table.ForeignKey(
                        name: "FK_Visitas_Porcinos_PorcinoID",
                        column: x => x.PorcinoID,
                        principalTable: "Porcinos",
                        principalColumn: "PorcinoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitas_Veterinarios_VeterinarioTarjetaProfesional",
                        column: x => x.VeterinarioTarjetaProfesional,
                        principalTable: "Veterinarios",
                        principalColumn: "TarjetaProfesional");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DireccionID",
                table: "Personas",
                column: "DireccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Porcinos_HistoriaClinicaHistoriaID",
                table: "Porcinos",
                column: "HistoriaClinicaHistoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Porcinos_PropietarioEmail",
                table: "Porcinos",
                column: "PropietarioEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Propietarios_PersonaID",
                table: "Propietarios",
                column: "PersonaID");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarios_PersonaID",
                table: "Veterinarios",
                column: "PersonaID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_PorcinoID",
                table: "Visitas",
                column: "PorcinoID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_VeterinarioTarjetaProfesional",
                table: "Visitas",
                column: "VeterinarioTarjetaProfesional");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "Porcinos");

            migrationBuilder.DropTable(
                name: "Veterinarios");

            migrationBuilder.DropTable(
                name: "HistoriasClinicas");

            migrationBuilder.DropTable(
                name: "Propietarios");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Direcciones");
        }
    }
}

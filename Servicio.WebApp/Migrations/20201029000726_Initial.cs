using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Servicio.WebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    nombreCliente = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clienteId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    codigo = table.Column<string>(nullable: false),
                    nombreTecnico = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tecnicoId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenServicios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaConsolidacion = table.Column<DateTime>(nullable: true),
                    FechaAnulacion = table.Column<DateTime>(nullable: true),
                    FechaFinalizacion = table.Column<DateTime>(nullable: true),
                    estado = table.Column<int>(nullable: false),
                    precio = table.Column<string>(nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ordenServicioId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenServicios_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrdenServicioId = table.Column<Guid>(nullable: true),
                    codigo = table.Column<string>(nullable: false),
                    direccion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_OrdenServicios_OrdenServicioId",
                        column: x => x.OrdenServicioId,
                        principalTable: "OrdenServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleServicios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrdenServicioId = table.Column<Guid>(nullable: true),
                    fechaDetalle = table.Column<DateTime>(nullable: false),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleServicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleServicios_OrdenServicios_OrdenServicioId",
                        column: x => x.OrdenServicioId,
                        principalTable: "OrdenServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CitaTecnicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TecnicoId = table.Column<Guid>(nullable: true),
                    CitaId = table.Column<Guid>(nullable: true),
                    codigo = table.Column<string>(nullable: false),
                    fechaHora = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaTecnicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitaTecnicos_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitaTecnicos_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CitaId = table.Column<Guid>(nullable: true),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleCitas_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormularioTrabajos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CitaId = table.Column<Guid>(nullable: true),
                    Informe = table.Column<string>(nullable: false),
                    MedidaAtencion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioTrabajos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormularioTrabajos_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_OrdenServicioId",
                table: "Citas",
                column: "OrdenServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaTecnicos_CitaId",
                table: "CitaTecnicos",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_CitaTecnicos_TecnicoId",
                table: "CitaTecnicos",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCitas_CitaId",
                table: "DetalleCitas",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleServicios_OrdenServicioId",
                table: "DetalleServicios",
                column: "OrdenServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioTrabajos_CitaId",
                table: "FormularioTrabajos",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicios_ClienteId",
                table: "OrdenServicios",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitaTecnicos");

            migrationBuilder.DropTable(
                name: "DetalleCitas");

            migrationBuilder.DropTable(
                name: "DetalleServicios");

            migrationBuilder.DropTable(
                name: "FormularioTrabajos");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "OrdenServicios");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Ilia.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CliCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: false),
                    CliNome = table.Column<string>(type: "varchar(max)", nullable: false),
                    CliEmail = table.Column<string>(type: "varchar(max)", nullable: false),
                    PrincipalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CliCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CliCliente_CliCliente_PrincipalId",
                        column: x => x.PrincipalId,
                        principalTable: "CliCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EndEndereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: false),
                    EndRua = table.Column<string>(type: "varchar(max)", nullable: false),
                    EndNumero = table.Column<int>(type: "int", nullable: false),
                    EndCEP = table.Column<string>(type: "varchar(10)", nullable: false),
                    EndCidade = table.Column<string>(type: "varchar(max)", nullable: false),
                    EndEstado = table.Column<string>(type: "varchar(max)", nullable: false),
                    EndPais = table.Column<string>(type: "varchar(max)", nullable: false),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndEndereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndEndereco_CliCliente_ClientId",
                        column: x => x.ClientId,
                        principalTable: "CliCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelTelefone",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataHoraCriacao = table.Column<DateTime>(nullable: false),
                    DataHoraAlteracao = table.Column<DateTime>(nullable: false),
                    TelNumero = table.Column<string>(type: "varchar(10)", nullable: false),
                    TelTipoTelefone = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelTelefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelTelefone_CliCliente_ClientId",
                        column: x => x.ClientId,
                        principalTable: "CliCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CliCliente_PrincipalId",
                table: "CliCliente",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_EndEndereco_ClientId",
                table: "EndEndereco",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TelTelefone_ClientId",
                table: "TelTelefone",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EndEndereco");

            migrationBuilder.DropTable(
                name: "TelTelefone");

            migrationBuilder.DropTable(
                name: "CliCliente");
        }
    }
}

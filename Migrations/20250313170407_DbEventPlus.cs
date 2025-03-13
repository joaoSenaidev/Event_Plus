using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Plus.Migrations
{
    /// <inheritdoc />
    public partial class DbEventPlus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.IdInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    IdPresenca = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situacao = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.IdPresenca);
                });

            migrationBuilder.CreateTable(
                name: "TipoEventos",
                columns: table => new
                {
                    IdTipoEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoEvento = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEventos", x => x.IdTipoEvento);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuarios",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoUsuario = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuarios", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEvento = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    IdTipoEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PresencaIdPresenca = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_Eventos_Instituicoes_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalTable: "Instituicoes",
                        principalColumn: "IdInstituicao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventos_Presenca_PresencaIdPresenca",
                        column: x => x.PresencaIdPresenca,
                        principalTable: "Presenca",
                        principalColumn: "IdPresenca");
                    table.ForeignKey(
                        name: "FK_Eventos_TipoEventos_IdTipoEvento",
                        column: x => x.IdTipoEvento,
                        principalTable: "TipoEventos",
                        principalColumn: "IdTipoEvento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    IdTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoUsuarios_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "TipoUsuarios",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioEventos",
                columns: table => new
                {
                    IdComentarioEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Exibe = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioEventos", x => x.IdComentarioEvento);
                    table.ForeignKey(
                        name: "FK_ComentarioEventos_Eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "Eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentarioEventos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEventos_IdEvento",
                table: "ComentarioEventos",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEventos_IdUsuario",
                table: "ComentarioEventos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdInstituicao",
                table: "Eventos",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdTipoEvento",
                table: "Eventos",
                column: "IdTipoEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_PresencaIdPresenca",
                table: "Eventos",
                column: "PresencaIdPresenca");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicoes_CNPJ",
                table: "Instituicoes",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioEventos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Instituicoes");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "TipoEventos");

            migrationBuilder.DropTable(
                name: "TipoUsuarios");
        }
    }
}

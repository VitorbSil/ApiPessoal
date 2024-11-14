using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIPessoal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CONTRATOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Cliente = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Prestador = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTRATOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_DOCUMENTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Tipo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Observacoes = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Assinado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DOCUMENTOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PARTES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Tipo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    DocumentoIdentidade = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Endereco = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PARTES", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_CONTRATOS",
                columns: new[] { "Id", "Cliente", "DataFim", "DataInicio", "Prestador", "Status", "Titulo", "Valor" },
                values: new object[,]
                {
                    { 1, "ETEC", new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "EscritórioX", "Ativo", "Primeiro Contrato", 1300m },
                    { 2, "Casa de Bolo", new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "EscritórioY", "Desativado", "Segundo Contrato", 2500m },
                    { 3, "Mercadinho", new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "EscritórioZ", "Ativo", "Terceiro Contrato", 800m }
                });

            migrationBuilder.InsertData(
                table: "TB_DOCUMENTOS",
                columns: new[] { "Id", "Assinado", "DataCriacao", "Observacoes", "Status", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Contrato de prestação de serviços firmado entre as partes.", "Ativo", "Contrato", "Contrato de Prestação de Serviços" },
                    { 2, false, new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Procuração para representação legal do cliente.", "Ativo", "Procuração", "Procuração" },
                    { 3, false, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Certidão de casamento registrada em cartório.", "Ativo", "Certidão", "Certidão de Casamento" }
                });

            migrationBuilder.InsertData(
                table: "TB_PARTES",
                columns: new[] { "Id", "DocumentoIdentidade", "Email", "Endereco", "Nome", "Telefone", "Tipo" },
                values: new object[,]
                {
                    { 1, "RG", "vitor@email.com", "Rua 1, Bairro A, Cidade X", "Vitor", "1234-5678", "Cliente" },
                    { 2, "OAB", "ana@adv.com", "Rua 2, Bairro B, Cidade Y", "Ana", "2345-6789", "Advogado" },
                    { 3, "CPF", "carlos@teste.com", "Rua 3, Bairro C, Cidade Z", "Carlos", "3456-7890", "Testemunha" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONTRATOS");

            migrationBuilder.DropTable(
                name: "TB_DOCUMENTOS");

            migrationBuilder.DropTable(
                name: "TB_PARTES");
        }
    }
}

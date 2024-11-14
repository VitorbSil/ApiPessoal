using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIPessoal.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoConexaoComBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParteId",
                table: "TB_DOCUMENTOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParteId",
                table: "TB_CONTRATOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_CONTRATOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_CONTRATOS",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_CONTRATOS",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_DOCUMENTOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_DOCUMENTOS",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_DOCUMENTOS",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParteId",
                value: 1);

            migrationBuilder.InsertData(
                table: "TB_DOCUMENTOS",
                columns: new[] { "Id", "Assinado", "DataCriacao", "Observacoes", "ParteId", "Status", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { 4, false, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alvará de Soltura esperando análise do Juiz.", 3, "Pendente", "Alvará", "Alvará de Soltura" },
                    { 5, true, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petição cadastrada e enviada para o Juiz.", 3, "Ativo", "Petição", "Petição de Invertário" },
                    { 6, false, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mandado de Busca aguardando assinatura do judiciário", 2, "Pendente", "Mandato", "Mandato de Busca" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_DOCUMENTOS_ParteId",
                table: "TB_DOCUMENTOS",
                column: "ParteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTRATOS_ParteId",
                table: "TB_CONTRATOS",
                column: "ParteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CONTRATOS_TB_PARTES_ParteId",
                table: "TB_CONTRATOS",
                column: "ParteId",
                principalTable: "TB_PARTES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_DOCUMENTOS_TB_PARTES_ParteId",
                table: "TB_DOCUMENTOS",
                column: "ParteId",
                principalTable: "TB_PARTES",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CONTRATOS_TB_PARTES_ParteId",
                table: "TB_CONTRATOS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_DOCUMENTOS_TB_PARTES_ParteId",
                table: "TB_DOCUMENTOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_DOCUMENTOS_ParteId",
                table: "TB_DOCUMENTOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_CONTRATOS_ParteId",
                table: "TB_CONTRATOS");

            migrationBuilder.DeleteData(
                table: "TB_DOCUMENTOS",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TB_DOCUMENTOS",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TB_DOCUMENTOS",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "ParteId",
                table: "TB_DOCUMENTOS");

            migrationBuilder.DropColumn(
                name: "ParteId",
                table: "TB_CONTRATOS");
        }
    }
}

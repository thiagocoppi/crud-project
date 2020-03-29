using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class RemovendoCamposDesnecessarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificadorrf",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "Tipopessoa",
                table: "Fornecedor");

            migrationBuilder.AddColumn<string>(
                name: "RG",
                table: "Fornecedor",
                nullable: true,
                comment: "RG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RG",
                table: "Fornecedor");

            migrationBuilder.AddColumn<string>(
                name: "Identificadorrf",
                table: "Fornecedor",
                type: "nvarchar(max)",
                nullable: true,
                comment: "CPF ou CNPJ");

            migrationBuilder.AddColumn<int>(
                name: "Tipopessoa",
                table: "Fornecedor",
                type: "int",
                nullable: true);
        }
    }
}

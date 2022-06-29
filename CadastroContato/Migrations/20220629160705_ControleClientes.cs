using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroContato.Migrations
{
    public partial class ControleClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Contato",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Contato",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Contato");
        }
    }
}

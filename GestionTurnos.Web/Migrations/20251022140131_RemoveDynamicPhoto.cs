using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionTurnos.Web.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDynamicPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Afiliados");

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Afiliados",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Afiliados",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Afiliados");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Afiliados",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}

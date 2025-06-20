using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UsuarioAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Rm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    IdTipoPerfil = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<int>(type: "int", nullable: false),
                    ChamadosAbertos = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    ChamadosConcluidos = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Rm);
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Rm", "ChamadosAbertos", "ChamadosConcluidos", "Email", "IdTipoPerfil", "Nome", "Senha", "Telefone" },
                values: new object[,]
                {
                    { 123090, "1", "2", "Maria@gmail.com", 3, "Maria", 123456, "11 988871234" },
                    { 123980, "5", "1", "João@gmail.com", 2, "João", 180805, "11 911876543" },
                    { 150570, "0", "3", "Marcela@gmail.com", 3, "Marcela", 30505, "11 955478756" },
                    { 201190, "2", "5", "Eduardo@gmail.com", 1, "Eduardo", 567890, "11 908879876" },
                    { 339090, "3", "2", "Claudia@gmail.com", 3, "Claudia", 456321, "11 989971774" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USUARIOS");
        }
    }
}

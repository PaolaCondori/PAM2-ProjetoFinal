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
                    Rm = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    TipoPerfil = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    ChamadosAbertos = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    ChamadosConcluidos = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    SenhaHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SenhaSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Rm);
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Rm", "ChamadosAbertos", "ChamadosConcluidos", "Email", "Nome", "Senha", "SenhaHash", "SenhaSalt", "Telefone", "TipoPerfil" },
                values: new object[,]
                {
                    { 123090, "1", "2", "Maria@gmail.com", "Maria", "123456", null, null, "11 988871234", "Funcionario" },
                    { 123980, "5", "1", "João@gmail.com", "João", "180805", null, null, "11 911876543", "GestorDepartamento" },
                    { 150570, "0", "3", "Marcela@gmail.com", "Marcela", "030505", null, null, "11 955478756", "Funcionario" },
                    { 201190, "2", "5", "Eduardo@gmail.com", "Eduardo", "567890", null, null, "11 908879876", "GestorGeral" },
                    { 339090, "3", "2", "Claudia@gmail.com", "Claudia", "456321", null, null, "11 989971774", "Funcionário" }
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

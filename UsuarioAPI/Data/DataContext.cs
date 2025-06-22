using Microsoft.EntityFrameworkCore;
using UsuarioAPI.Models;
using UsuarioAPI.Utils;

namespace UsuarioAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuario> TB_USUARIOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            modelBuilder.Entity<Usuario>().HasKey(u => u.Rm);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario() { Rm = 123090, Nome = "Maria", Email = "Maria@gmail.com", Senha = "123456", Telefone = "11 988871234", IdTipoPerfil = 3, ChamadosAbertos = "1", ChamadosConcluidos = "2" },
                new Usuario() { Rm = 201190, Nome = "Eduardo", Email = "Eduardo@gmail.com", Senha = "567890", Telefone = "11 908879876", IdTipoPerfil = 1, ChamadosAbertos = "2", ChamadosConcluidos = "5" },
                new Usuario() { Rm = 339090, Nome = "Claudia", Email = "Claudia@gmail.com", Senha = "456321", Telefone = "11 989971774", IdTipoPerfil = 3, ChamadosAbertos = "3", ChamadosConcluidos = "2" },
                new Usuario() { Rm = 123980, Nome = "João", Email = "João@gmail.com", Senha = "180805", Telefone = "11 911876543", IdTipoPerfil = 2, ChamadosAbertos = "5", ChamadosConcluidos = "1" },
                new Usuario() { Rm = 150570, Nome = "Marcela", Email = "Marcela@gmail.com", Senha = "030505", Telefone = "11 955478756", IdTipoPerfil = 3, ChamadosAbertos = "0", ChamadosConcluidos = "3" }
            );

            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("senha1234", out byte[] hash, out byte[] salt);
            user.Rm = 112233;
            user.Nome = "UsuarioAdmin";
            user.Email = "admin@gmail.com";
            user.Telefone = "11 985729275";
            user.IdTipoPerfil = 1;
            user.Senha = string.Empty;
            user.ChamadosAbertos = string.Empty;
            user.ChamadosConcluidos = string.Empty;
            user.SenhaHash = hash;
            user.SenhaSalt = salt;
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("Varchar").HaveMaxLength(200);
        }
    } 
}
namespace UsuarioAPI.Models
{
    public class Usuario
    {
        public int Rm { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string TipoPerfil { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string ChamadosAbertos { get; set; } = string.Empty;
        public string ChamadosConcluidos { get; set; } = string.Empty;
        public byte[]? SenhaHash { get; set; }
        public byte[]? SenhaSalt { get; set; }
    }

}

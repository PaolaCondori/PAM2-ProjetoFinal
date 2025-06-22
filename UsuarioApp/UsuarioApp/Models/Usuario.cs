using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Models
{
    public class Usuario
    {
        public int Rm { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public int IdTipoPerfil { get; set; }
        public string Senha { get; set; } = string.Empty;
        public string Token { get; set; }
        public string ChamadosAbertos { get; set; } = string.Empty;
        public string ChamadosConcluidos { get; set; } = string.Empty;
        public byte[]? SenhaHash { get; set; }
        public byte[]? SenhaSalt { get; set; }
    }
}

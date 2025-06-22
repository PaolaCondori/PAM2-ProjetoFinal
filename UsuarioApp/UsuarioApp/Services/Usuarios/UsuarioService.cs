using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Models;

namespace UsuarioApp.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;
        private readonly string apiUrlBase = "api";
        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Registrar";
            u.Rm = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u, string.Empty);
            return u;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Autenticar";
            u = await _request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);
            
            return u;
        }

        //GetAll
        //AlterarSenha
        //Rm
    }
}

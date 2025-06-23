using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Models;

namespace UsuarioApp.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "";

        private string _token;
        public UsuarioService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<ObservableCollection<Usuario>> GetUsuariosAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<Models.Usuario> listaUsuarios = await
            _request.GetAsync<ObservableCollection<Models.Usuario>>(apiUrlBase +
            urlComplementar, _token);

            return listaUsuarios;
        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Registrar";
            u.Rm = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u, string.Empty);
            return u;
        }

        public async Task<int> PutAlterarSenhaUsuarioAsync(Usuario u)
        {
            var result = await _request.PutAsync(apiUrlBase, u, _token);
            return result;
        }

        public async Task<Usuario> GetUsuarioAsync(int userRm)
        {
            string urlComplementar = string.Format("/{0}", userRm);
            var usuario = await _request.GetAsync<Models.Usuario>(apiUrlBase +
                urlComplementar, _token);

            return usuario;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Autenticar";
            u = await _request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);
            
            return u;
        }
    }
}

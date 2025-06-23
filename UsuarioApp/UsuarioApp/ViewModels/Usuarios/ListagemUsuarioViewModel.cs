using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UsuarioApp.Models;
using UsuarioApp.Services.Usuarios;

namespace UsuarioApp.ViewModels.Usuarios
{
    public class ListagemUsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        public ObservableCollection<Usuario> Usuarios { get; set; }
        public ListagemUsuarioViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            uService = new UsuarioService(token);
            Usuarios = new ObservableCollection<Usuario>();
            _ = ObterUsuarios();

            NovoUsuarioCommand = new Command(async () => { await ExibirCadastroUsuario(); });
        }

        public ICommand NovoUsuarioCommand { get; }

        public async Task ObterUsuarios()
        {
            try
            {
                Usuarios = await uService.GetUsuariosAsync();
                OnPropertyChanged(nameof(Usuarios));
            } 
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task ExibirCadastroUsuario()
        {
            try
            {
                await Shell.Current.GoToAsync("cadUsuarioView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}

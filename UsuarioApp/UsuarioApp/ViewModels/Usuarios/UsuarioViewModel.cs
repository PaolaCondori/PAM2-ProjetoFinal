using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UsuarioApp.Models;
using UsuarioApp.Services.Usuarios;
using UsuarioApp.Views.Usuarios;

namespace UsuarioApp.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        public ICommand AutenticarCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }
        public UsuarioViewModel() 
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            uService = new UsuarioService(token);
            InicializarCommands(); 
        }

        public void InicializarCommands()
        {
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
            RegistrarCommand = new Command(async () => await RegistrarUsuario());
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
        }

        #region AtributosPropriedades

        private int rm;
        private string nome = string.Empty;
        private string email = string.Empty;
        private string telefone = string.Empty;
        private string tipoPerfil = string.Empty;
        private string senha = string.Empty;
        private string chamadosAbertos = string.Empty;
        private string chamadosConcluidos = string.Empty;

        public int Rm
        {
            get => rm;
            set
            {
                rm = value;
                OnPropertyChanged();
            }
        }
        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public string Telefone
        {
            get => telefone;
            set
            {
                telefone = value;
                OnPropertyChanged();
            }
        }
        public string TipoPerfil
        {
            get => tipoPerfil;
            set
            {
                tipoPerfil = value;
                OnPropertyChanged();
            }
        }
        public string Senha
        {
            get => senha;
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }
        public string ChamadosAbertos
        {
            get => chamadosAbertos;
            set
            {
                chamadosAbertos = value;
                OnPropertyChanged();
            }
        }
        public string ChamadosConcluidos
        {
            get => chamadosConcluidos;
            set
            {
                chamadosConcluidos = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Nome = nome;
                u.Senha = senha;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticado.Token))
                {
                    string mensagem = $"Bem-vindo(a) {uAutenticado.Nome}.";

                    Preferences.Set("UsuarioRm", uAutenticado.Rm);
                    Preferences.Set("UsuarioNome", uAutenticado.Nome);
                    Preferences.Set("UsuarioToken", uAutenticado.Token);

                    await Application.Current.MainPage
                        .DisplayAlert("Informação", mensagem, "Ok");

                    Application.Current.MainPage = new AppShell();
                }
                else 
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados Incorretos ;[", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        #region Métodos
        public async Task RegistrarUsuario()
        {
            try
            {
                Usuario model = new Usuario()
                {
                    Rm = this.rm,
                    Nome = this.nome,
                    Email = this.email,
                    Telefone = this.telefone,
                    TipoPerfil = this.TipoPerfil,
                    Senha = this.senha,
                    ChamadosAbertos = this.chamadosAbertos,
                    ChamadosConcluidos = this.chamadosConcluidos
                };
                if (model.Rm != 0)
                   await uService.PostRegistrarUsuarioAsync(model);

                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaCadastro()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new CadastroView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.Message, "Ok");
            }
        }

        #endregion
    }
}

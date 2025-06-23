using UsuarioApp.Views.Usuarios;

namespace UsuarioApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("cadUsuarioView", typeof(CadastroView));
        }
    }
}

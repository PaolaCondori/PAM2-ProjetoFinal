using UsuarioApp.ViewModels.Usuarios;

namespace UsuarioApp.Views.Usuarios;

public partial class EdicaoUsuarioView : ContentPage
{
	private UsuarioViewModel edViewModel;
	public EdicaoUsuarioView()
	{
		InitializeComponent();

		edViewModel = new UsuarioViewModel();
		BindingContext = edViewModel;
		Title = "Editar Usuário";
	}
}
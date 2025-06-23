using UsuarioApp.ViewModels.Usuarios;

namespace UsuarioApp.Views.Usuarios;

public partial class ListagemView : ContentPage
{
	ListagemUsuarioViewModel viewModel;

	public ListagemView()
	{
		InitializeComponent();

		viewModel = new ListagemUsuarioViewModel();
		BindingContext = viewModel;
		Title = "Usuarios - App";
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_ = viewModel.ObterUsuarios();
    }
}
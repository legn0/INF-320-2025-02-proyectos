using GastosApp.ViewModels;

namespace GastosApp;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        // Alerta de transacciones!!
        viewModel.MostrarAlerta = async (titulo, mensaje, boton) =>
        {
            await DisplayAlert(titulo, mensaje, boton);
        };
    }
}

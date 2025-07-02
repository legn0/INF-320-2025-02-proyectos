using GastosApp.ViewModels;

namespace GastosApp;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        // Manejo de alertas(pop-up) para las transacciones
        viewModel.MostrarAlerta = async (titulo, mensaje, boton) =>
        {
            await DisplayAlert(titulo, mensaje, boton);
        };
    }
}

using GastosApp.ViewModels;

namespace GastosApp;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        // Sección para habilitar las alertas en la app en relación al formulario de transacciones.
        viewModel.MostrarAlerta = async (titulo, mensaje, boton) =>
        {
            await DisplayAlert(titulo, mensaje, boton);
        };
    }
}

using GastosApp.ViewModels;

namespace GastosApp;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as HomeViewModel)?.CargarDatos();
    }
}
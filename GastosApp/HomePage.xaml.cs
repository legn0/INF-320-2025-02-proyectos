using GastosApp.Services;
using GastosApp.ViewModels;

namespace GastosApp;

public partial class HomePage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public HomePage(HomeViewModel vm, DatabaseService databaseService)
    {
        InitializeComponent();
        BindingContext = vm;
        _databaseService = databaseService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as HomeViewModel)?.CargarDatos();

        string userName = await _databaseService.GetSettingAsync("UserName");
        if (!string.IsNullOrEmpty(userName))
        {
            UserNameLabel.Text = $"Hola, {userName}!";
        }
    }
}
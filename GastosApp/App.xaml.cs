using GastosApp.Services;

namespace GastosApp;

public partial class App : Application
{
    private readonly DatabaseService _databaseService;

    public App(DatabaseService databaseService)
    {
        InitializeComponent();

        _databaseService = databaseService;
        CheckAndPromptForUserName();

        MainPage = new AppShell();
    }

    private async void CheckAndPromptForUserName()
    {
        string userName = await _databaseService.GetSettingAsync("UserName");
        if (string.IsNullOrEmpty(userName))
        {
            userName = await Shell.Current.DisplayPromptAsync("Bienvenido", "¿Cuál es tu nombre?", "Ok", "Cancelar");
            if (!string.IsNullOrEmpty(userName))
            {
                await _databaseService.SaveSettingAsync("UserName", userName);
            }
        }
    }
}
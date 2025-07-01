using GastosApp.Services;
using GastosApp.ViewModels;

namespace GastosApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddSingleton<DatabaseService>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<HomeViewModel>();

		return builder.Build();
	}
}
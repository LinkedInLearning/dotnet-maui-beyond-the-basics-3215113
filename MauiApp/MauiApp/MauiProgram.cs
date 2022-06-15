using MauiBeyond.Interfaces;
using MauiBeyond.Services;
using MauiBeyond.ViewModels;

namespace MauiBeyond;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddTransient<MainViewPage>();

        builder.Services.AddTransient<MainViewModel>();

		builder.Services.AddTransient<IAddressService, AddressService>();

        return builder.Build();
	}
}

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
        builder.Services.AddTransient<LandingPage>();
        builder.Services.AddTransient<FlexLayoutPage>();
        builder.Services.AddTransient<ListViewPage>();
        builder.Services.AddTransient<CollectionViewPage>();
        

        builder.Services.AddTransient<PagedCollectionViewModel>();
        builder.Services.AddTransient<ListViewModel>();

        builder.Services.AddSingleton<NamesService>();

        return builder.Build();
	}
}

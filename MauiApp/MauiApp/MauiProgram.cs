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
        builder.Services.AddTransient<GridPage>();
        builder.Services.AddTransient<StackPage>();
        builder.Services.AddTransient<FlexPage>();
        builder.Services.AddTransient<FlexListPage>();
        builder.Services.AddTransient<AbsolutePage>();
        builder.Services.AddTransient<TableViewPage>();

        builder.Services.AddTransient<FlexListViewModel>();

        return builder.Build();
	}
}

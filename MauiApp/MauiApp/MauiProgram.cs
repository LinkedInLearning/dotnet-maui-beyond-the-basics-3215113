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

#if ANDROID
        Microsoft.Maui.Handlers.ImageHandler.Mapper.ModifyMapping(nameof(Image.IsVisible), (handler, view, action) =>
        {
            var myView = handler.PlatformView;

            if (myView.Visibility == Android.Views.ViewStates.Visible)
            {
                myView.Visibility = Android.Views.ViewStates.Gone;
            }
            else
            {
                var width = myView.Width > 0 ? myView.Width / 2 : 500;
                var height = myView.Height > 0 ? myView.Height / 2 : 300;

                float finalRadius = (float)Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2));

                var anim = Android.Views.ViewAnimationUtils.CreateCircularReveal(myView, width, height, 0f, finalRadius);
                myView.Visibility = Android.Views.ViewStates.Visible;
                anim.Start();
            }
        });
#endif

        return builder.Build();
	}
}

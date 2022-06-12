using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class MainViewPage : ContentPage
{
	public MainViewPage(MainViewModel mainViewModel)
    {
        BindingContext = mainViewModel;

        InitializeComponent();
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(AppShell.EDIT_ADDRESS_ROUTE, true);
    }

    private async void Address_Tapped(object sender, EventArgs e)
    {
        var address = ((Element)sender).BindingContext;
        var navigationParameters = new Dictionary<string, object>
        {
            { AppShell.ADDRESS_PARAMETER, address }
        };
        await Shell.Current.GoToAsync($"{AppShell.EDIT_ADDRESS_ROUTE}", true, navigationParameters);
    }
}
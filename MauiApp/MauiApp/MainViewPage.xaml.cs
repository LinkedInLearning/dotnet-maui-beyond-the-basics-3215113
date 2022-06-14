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
        await Shell.Current.GoToAsync(AppShell.EDIT_CONTACT_ROUTE, true);
    }

    private async void Contact_Tapped(object sender, EventArgs e)
    {
        var contactItem = ((Models.ContactItem)((Element)sender).BindingContext);
        var navigationParameters = new Dictionary<string, object>
        {
            { AppShell.CONTACT_ID_PARAMETER, contactItem.Id.ToString() }
        };
        await Shell.Current.GoToAsync($"{AppShell.EDIT_CONTACT_ROUTE}", true, navigationParameters);
    }
}
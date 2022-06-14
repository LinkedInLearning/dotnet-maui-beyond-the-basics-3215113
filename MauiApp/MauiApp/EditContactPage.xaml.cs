using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class EditContactPage : ContentPage
{
	public EditContactPage(EditContactViewModel editAddressViewModel)
	{
        BindingContext = editAddressViewModel;

		InitializeComponent();
	}

    private async void Cancel_Button_Clicked(object sender, EventArgs e)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { AppShell.CONTACT_PARAMETER, null }
        };
        await Shell.Current.GoToAsync("..", true, navigationParameter);
    }
}
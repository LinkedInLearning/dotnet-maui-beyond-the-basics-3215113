using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class EditAddressPage : ContentPage
{
	public EditAddressPage(EditAddressViewModel editAddressViewModel)
	{
        BindingContext = editAddressViewModel;

		InitializeComponent();
	}

    private async void Cancel_Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
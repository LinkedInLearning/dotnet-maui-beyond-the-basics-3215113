using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class MainViewPage : ContentPage
{
    private const int MOVE_DISTANCE = 40;
	public MainViewPage(MainViewModel mainViewModel)
    {
        BindingContext = mainViewModel;

        InitializeComponent();

        address1.Focused += Address1_Focused;
        address2.Focused += Address2_Focused;
        city.Focused += City_Focused;
        state.Focused += State_Focused;
        postalCode.Focused += PostalCode_Focused;
    }

    private void PostalCode_Focused(object sender, FocusEventArgs e)
    {
        MoveIndicator(MOVE_DISTANCE * 4);
    }

    private void State_Focused(object sender, FocusEventArgs e)
    {
        MoveIndicator(MOVE_DISTANCE * 3);
    }

    private void City_Focused(object sender, FocusEventArgs e)
    {
        MoveIndicator(MOVE_DISTANCE * 2);
    }

    private void Address2_Focused(object sender, FocusEventArgs e)
    {
        MoveIndicator(MOVE_DISTANCE * 1);
    }

    private void Address1_Focused(object sender, FocusEventArgs e)
    {
        MoveIndicator(MOVE_DISTANCE * 0);
    }

    private void MoveIndicator(int distance)
    {
        focusIndicator.TranslateTo(0, distance, 400, Easing.BounceOut);
    }
}
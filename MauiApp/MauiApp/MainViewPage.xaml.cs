using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class MainViewPage : ContentPage
{
    private const int MOVE_DISTANCE = 40;
	public MainViewPage(MainViewModel mainViewModel)
    {
        BindingContext = mainViewModel;

        InitializeComponent();
    }
}
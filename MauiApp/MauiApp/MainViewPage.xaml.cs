using MauiBeyond.Animations;
using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class MainViewPage : ContentPage
{
	public MainViewPage(MainViewModel mainViewModel)
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        catImage.PopAnimation();
    }
}
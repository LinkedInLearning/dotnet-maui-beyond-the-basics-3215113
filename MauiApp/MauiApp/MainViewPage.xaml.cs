using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class MainViewPage : ContentPage
{
	public MainViewPage(MainViewModel pageCollectionViewModel)
    {
        BindingContext = pageCollectionViewModel;

        InitializeComponent();
    }
}
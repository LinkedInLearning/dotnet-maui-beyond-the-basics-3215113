using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class MainViewPage : BasePage<MainViewModel>
{
	public MainViewPage(MainViewModel pageCollectionViewModel) : base(pageCollectionViewModel)
    {
        InitializeComponent();
    }
}
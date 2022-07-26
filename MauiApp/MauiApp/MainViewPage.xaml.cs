
using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class MainViewPage : BasePage<MainViewModel>
{
	public MainViewPage(MainViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}
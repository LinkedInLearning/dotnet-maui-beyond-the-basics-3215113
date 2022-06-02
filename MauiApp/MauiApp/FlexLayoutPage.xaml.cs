using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class FlexLayoutPage : ContentPage
{
	public FlexLayoutPage(ListViewModel listViewModel)
	{
		InitializeComponent();

		BindingContext = listViewModel;
	}
}
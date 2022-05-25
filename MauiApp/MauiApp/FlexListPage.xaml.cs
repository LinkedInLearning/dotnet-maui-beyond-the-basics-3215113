using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class FlexListPage : ContentPage
{
	public FlexListPage(FlexListViewModel flexListViewModel)
	{
		BindingContext = flexListViewModel;

		InitializeComponent();
	}
}
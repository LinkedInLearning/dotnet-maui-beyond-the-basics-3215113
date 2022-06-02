using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class ListViewPage : ContentPage
{
	public ListViewPage(ListViewModel listViewModel)
	{
		InitializeComponent();

		BindingContext = listViewModel;

    }
}
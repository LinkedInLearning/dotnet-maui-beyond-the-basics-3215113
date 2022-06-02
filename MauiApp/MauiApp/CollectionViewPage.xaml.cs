using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class CollectionViewPage : ContentPage
{
	public CollectionViewPage(PagedCollectionViewModel pageCollectionViewModel)
	{
		InitializeComponent();

		BindingContext = pageCollectionViewModel;
	}
}
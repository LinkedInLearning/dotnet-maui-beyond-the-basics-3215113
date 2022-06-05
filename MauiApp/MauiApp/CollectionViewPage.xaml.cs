using MauiBeyond.ViewModels;

namespace MauiBeyond;

public partial class CollectionViewPage : ContentPage
{
	public CollectionViewPage(CollectionViewModel pageCollectionViewModel)
	{
		InitializeComponent();

		BindingContext = pageCollectionViewModel;
	}
}
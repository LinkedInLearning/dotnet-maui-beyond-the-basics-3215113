using MauiBeyond.ViewModels;

namespace MauiBeyond;

public class BasePage<T> : ContentPage where T: BaseViewModel
{
	public BasePage(T viewModel)
	{
        ViewModel = viewModel;
        BindingContext = this;
	}

    public static readonly BindableProperty ViewModelProperty =
    BindableProperty.Create(nameof(ViewModel), typeof(T), typeof(BasePage<T>), default(T), BindingMode.TwoWay);

    public T ViewModel
    {
        get => (T)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }

}
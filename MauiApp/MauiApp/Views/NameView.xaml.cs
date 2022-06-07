namespace MauiBeyond.Views;

public partial class NameView : ContentView
{
	public NameView()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(AddressView), string.Empty, BindingMode.TwoWay);

	public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }
}
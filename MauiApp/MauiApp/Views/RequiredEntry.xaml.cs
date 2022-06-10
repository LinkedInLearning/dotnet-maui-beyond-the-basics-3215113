namespace MauiBeyond.Views;

public partial class RequiredEntry : ContentView
{
	public RequiredEntry()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(RequiredEntry), string.Empty, BindingMode.TwoWay);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}
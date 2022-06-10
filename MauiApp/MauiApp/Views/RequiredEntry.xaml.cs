namespace MauiBeyond.Views;

public partial class RequiredEntry : ContentView
{
	public RequiredEntry()
	{
		InitializeComponent();
        HasTextChanged(this, string.Empty, string.Empty);

    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(RequiredEntry), string.Empty, BindingMode.TwoWay, null, HasTextChanged);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    private static void HasTextChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var newText = newValue as string;
        VisualStateManager.GoToState(((RequiredEntry)bindable).mainFrame, string.IsNullOrEmpty(newText) ? "NoText" : "HasText");
    }
}
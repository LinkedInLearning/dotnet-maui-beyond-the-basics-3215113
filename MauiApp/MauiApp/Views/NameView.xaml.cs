namespace MauiBeyond.Views;

public partial class NameView : ContentView
{
	public NameView(string prompt)
	{
        Prompt = prompt;
        InitializeComponent();
	}

    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(AddressView), string.Empty, BindingMode.TwoWay);

	public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public static readonly BindableProperty PromptProperty =
    BindableProperty.Create(nameof(Prompt), typeof(string), typeof(AddressView), string.Empty, BindingMode.TwoWay);

    public string Prompt
    {
        get => (string)GetValue(PromptProperty);
        private set => SetValue(PromptProperty, value);
    }
}
namespace MauiBeyond.Views;

public partial class FocusedEntry : Entry
{

    public FocusedEntry()
    {
        InitializeComponent();

        mainEntry.Focused += MainEntry_Focused;
        mainEntry.Unfocused += MainEntry_Unfocused;
    }

    private void MainEntry_Unfocused(object sender, FocusEventArgs e)
    {
        mainEntry.ScaleYTo(1, 500);
    }

    private void MainEntry_Focused(object sender, FocusEventArgs e)
    {
        mainEntry.ScaleYTo(1.5, 500);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(FocusedEntry), string.Empty, BindingMode.TwoWay, null);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}
namespace MauiBeyond.Views;

public partial class ErrorEntry : ContentView
{
    public ErrorEntry()
    {
        InitializeComponent();

        IsValidChanged(this, true, true);

    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ErrorEntry), string.Empty, BindingMode.TwoWay, null);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(ErrorEntry), true, BindingMode.OneWay, null, IsValidChanged);
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    private static void IsValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var isValid = Convert.ToBoolean(newValue);
        VisualStateManager.GoToState(((ErrorEntry)bindable).mainFrame, isValid? "Normal" : "Invalid");
    }
}
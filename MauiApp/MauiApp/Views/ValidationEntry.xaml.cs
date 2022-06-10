namespace MauiBeyond.Views;

public partial class ValidationEntry : Entry
{
	public ValidationEntry()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(ValidationEntry), true, BindingMode.TwoWay, null, IsValidChanged);
    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    private static void IsValidChanged(BindableObject bindable, object oldValue, object newValue)
    {
        VisualStateManager.GoToState((VisualElement)bindable, (bool)newValue ? "Valid" : "Invalid");
    }

}
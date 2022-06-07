namespace MauiBeyond.Views;

public partial class AddressView : ContentView
{
	public AddressView()
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

    public static readonly BindableProperty Address1Property =
    BindableProperty.Create(nameof(Address1), typeof(string), typeof(AddressView), string.Empty, BindingMode.TwoWay);

    public string Address1
    {
        get => (string)GetValue(Address1Property);
        set
        {
            if (value != (string)GetValue(Address1Property))
            {
                SetValue(Address1Property, value);
            }
        }
    }

    public static readonly BindableProperty Address2Property =
        BindableProperty.Create(nameof(Address2), typeof(string), typeof(AddressView), string.Empty, BindingMode.TwoWay);

    public string Address2
    {
        get => (string)GetValue(Address2Property);
        set
        {
            if (value != (string)GetValue(Address2Property))
            {
                SetValue(Address2Property, value);
            }
        }
    }

    public static readonly BindableProperty CityProperty =
        BindableProperty.Create(nameof(City), typeof(string), typeof(AddressView), string.Empty, BindingMode.TwoWay);

    public string City
    {
        get => (string)GetValue(CityProperty);
        set
        {
            if (value != (string)GetValue(CityProperty))
            {
                SetValue(CityProperty, value);
            }
        }
    }

    public static readonly BindableProperty StateProperty =
        BindableProperty.Create(nameof(State), typeof(string), typeof(AddressView), string.Empty, BindingMode.TwoWay);

    public string State
    {
        get => (string)GetValue(StateProperty);
        set
        {
            if (value != (string)GetValue(StateProperty))
            {
                SetValue(StateProperty, value);
            }
        }
    }

    public static readonly BindableProperty PostalCodeProperty =
        BindableProperty.Create(nameof(PostalCode), typeof(string), typeof(AddressView), string.Empty, BindingMode.TwoWay);

    public string PostalCode
    {
        get => (string)GetValue(PostalCodeProperty);
        set
        {
            if (value != (string)GetValue(PostalCodeProperty))
            {
                SetValue(PostalCodeProperty, value);
            }
        }
    }
}
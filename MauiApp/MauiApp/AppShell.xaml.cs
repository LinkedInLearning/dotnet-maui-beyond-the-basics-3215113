namespace MauiBeyond;

public partial class AppShell : Shell
{
    public const string EDIT_ADDRESS_ROUTE = "EditAddress";

    public const string ADDRESS_PARAMETER = "Address";

    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(EDIT_ADDRESS_ROUTE, typeof(EditAddressPage));
    }
}

namespace MauiBeyond;

public partial class AppShell : Shell
{
    public const string EDIT_CONTACT_ROUTE = "EditContact";

    public const string CONTACT_ID_PARAMETER = "ContactId";

    public const string CONTACT_PARAMETER = "Contact";

    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(EDIT_CONTACT_ROUTE, typeof(EditContactPage));
    }
}

namespace MauiBeyond.Views;

public partial class TitleLabel : Label
{
	private TitleLabel()
	{
		InitializeComponent();
	}

	public static TitleLabel CreateTitleLabel(string labelText)
    {
		return new TitleLabel
		{
			Text = labelText,
		};
    }
}
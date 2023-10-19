namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		//System.Diagnostics.Debug.WriteLine("AppShell");
		InitializeComponent();

        Items.Add(new ShellContent()
        {
            ContentTemplate = new DataTemplate(typeof(MainPage)),
            Title = "Início",
            Route = "MainPage"
        });

        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage) );
	}
}

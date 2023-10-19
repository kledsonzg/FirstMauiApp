namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
        //System.Diagnostics.Debug.WriteLine("App");
        InitializeComponent();

		MainPage = new AppShell();
	}
}

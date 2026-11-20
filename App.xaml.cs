namespace AppProject;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new Views.SignInPage();
	}
}

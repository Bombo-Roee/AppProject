using AppProject.ViewModels;

namespace AppProject.Views;

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
        BindingContext = new SignInViewModel();
    }
}

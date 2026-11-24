using AppProject.ViewModels;

namespace AppProject.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
        BindingContext = new SignUpViewModel();
    }
}

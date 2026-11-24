using System.Windows.Input;
using AppProject.Helpers;
using AppProject.Models;
using AppProject.Services;
using AppProject.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace AppProject.ViewModels;

public class SignUpViewModel : ViewModelBase
{
    #region Private Fields
    private readonly DBMokup _db;
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _email = string.Empty;
    private string _password = string.Empty;
    private string _mobile = string.Empty;
    private bool _entryAsPassword;
    private string _passwordIconCode = string.Empty;
    #endregion

    #region Constructor
    public SignUpViewModel()
    {
        _db = new DBMokup();
        _entryAsPassword = true;
        _passwordIconCode = FontHelper.CLOSED_EYE_ICON;

        ShowPasswordCommand = new Command(TogglePasswordButton);
        SignUpCommand = new Command(SignUp, Validate);
        NavigateToSignInCommand = new Command(NavigateToSignIn);
    }
    #endregion

    #region Commands
    public ICommand ShowPasswordCommand { get; }
    public ICommand SignUpCommand { get; }
    public ICommand NavigateToSignInCommand { get; }
    #endregion

    #region Private Methods
    private void TogglePasswordButton()
    {
        if (EntryAsPassword)
            PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
        else
            PasswordIconCode = FontHelper.OPEN_EYE_ICON;

        EntryAsPassword = !EntryAsPassword;
    }

    private bool Validate()
    {
        var fnameOK = !string.IsNullOrEmpty(FirstName);
        var lnameOK = !string.IsNullOrEmpty(LastName);
        var emailOK = !string.IsNullOrEmpty(UserEmail);
        var passOK = !string.IsNullOrEmpty(UserPassword) && UserPassword.Length > 5;
        var mobileOK = !string.IsNullOrEmpty(Mobile) && Mobile.Length == 10;
        return fnameOK && lnameOK && emailOK && passOK && mobileOK;
    }

    private async void SignUp()
    {
        _db.Add(new AppUser
        {
            FirstName = FirstName,
            LastName = LastName,
            UserEmail = UserEmail,
            UserPassword = UserPassword,
            Mobile = Mobile
        });

        await Toast.Make($"SignUp new user", ToastDuration.Short, 14).Show();

        if (Application.Current != null)
        {
            Application.Current.MainPage = new SignInPage();
        }
    }

    private void NavigateToSignIn()
    {
        if (Application.Current != null)
        {
            Application.Current.MainPage = new SignInPage();
        }
    }
    #endregion

    #region Public Properties
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (_firstName != value)
            {
                _firstName = value;
                OnPropertyChanged();
                (SignUpCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (_lastName != value)
            {
                _lastName = value;
                OnPropertyChanged();
                (SignUpCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    public string UserEmail
    {
        get => _email;
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged();
                (SignUpCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    public string UserPassword
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
                (SignUpCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    public string Mobile
    {
        get => _mobile;
        set
        {
            if (_mobile != value)
            {
                _mobile = value;
                OnPropertyChanged();
                (SignUpCommand as Command)?.ChangeCanExecute();
            }
        }
    }

    public bool EntryAsPassword
    {
        get => _entryAsPassword;
        set
        {
            if (_entryAsPassword != value)
            {
                _entryAsPassword = value;
                OnPropertyChanged();
            }
        }
    }

    public string PasswordIconCode
    {
        get => _passwordIconCode;
        set
        {
            if (_passwordIconCode != value)
            {
                _passwordIconCode = value;
                OnPropertyChanged();
            }
        }
    }
    #endregion
}

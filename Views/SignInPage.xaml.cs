using AppProject.Helpers;
using AppProject.Services;

namespace AppProject.Views;

public partial class SignInPage : ContentPage
{
    private string _userName = string.Empty;
    private string _password = string.Empty;
    private bool _entryAsPassword = true;
    private string _passwordIconCode = FontHelper.OPEN_EYE_ICON;
    private bool _signInMessageVisible;
    private string _loginMessage = string.Empty;
    private Color _signInMessageColor = Colors.Red;
    private readonly DBMokup _db;

    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName != value)
            {
                _userName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsSignInButtonEnabled));
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
                OnPropertyChanged(nameof(IsSignInButtonEnabled));
            }
        }
    }

    public bool IsSignInButtonEnabled =>
        !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));

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

    public string LoginMessage
    {
        get => _loginMessage;
        set
        {
            if (_loginMessage != value)
            {
                _loginMessage = value;
                OnPropertyChanged();
            }
        }
    }

    public bool SignInMessageVisible
    {
        get => _signInMessageVisible;
        set
        {
            if (_signInMessageVisible != value)
            {
                _signInMessageVisible = value;
                OnPropertyChanged();
            }
        }
    }

    public Color SignInMessageColor
    {
        get => _signInMessageColor;
        set
        {
            if (_signInMessageColor != value)
            {
                _signInMessageColor = value;
                OnPropertyChanged();
            }
        }
    }

    public SignInPage()
    {
        InitializeComponent();
        _entryAsPassword = true;
        _passwordIconCode = FontHelper.OPEN_EYE_ICON;
        _db = new DBMokup();
        _signInMessageColor = Colors.Red;
        _signInMessageVisible = false;
        BindingContext = this;
    }

    private void TogglePassordButtonClicked(object? sender, EventArgs e)
    {
        if (EntryAsPassword)
            PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
        else
            PasswordIconCode = FontHelper.OPEN_EYE_ICON;

        EntryAsPassword = !EntryAsPassword;
    }

    private void OnSignInButtonClick(object? sender, EventArgs e)
    {
        SignInMessageVisible = true;
        if (_db.IsExist(UserName, UserPassword))
        {
            LoginMessage = AppMessages.SignInMessageSuccess;
            SignInMessageColor = Colors.Green;
            // Navigate to MainPage
        }
        else
        {
            LoginMessage = AppMessages.SignMessageFail;
            SignInMessageColor = Colors.Red;
        }
    }
}


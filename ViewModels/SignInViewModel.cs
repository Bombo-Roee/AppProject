using System.Windows.Input;
using AppProject.Helpers;
using AppProject.Services;

namespace AppProject.ViewModels;

public class SignInViewModel : ViewModelBase
{
    #region Private Fields
    private readonly DBMokup _db;
    private string _userName = string.Empty;
    private string _password = string.Empty;
    private string _loginMessage = string.Empty;
    private bool _signInMessageVisible;
    private Color _signInMessageColor = Colors.Red;
    private bool _entryAsPassword;
    private string _passwordIconCode = string.Empty;
    #endregion

    #region Constructor
    public SignInViewModel()
    {
        _entryAsPassword = true;
        _passwordIconCode = FontHelper.CLOSED_EYE_ICON;
        _signInMessageVisible = false;
        _loginMessage = string.Empty;
        _signInMessageColor = Colors.Red;
        _db = new DBMokup();

        ShowPasswordCommand = new Command(TogglePassordButton);
        SignInCommand = new Command(SignIn, () =>
            !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword)));
    }
    #endregion

    #region Commands
    public ICommand ShowPasswordCommand { get; }
    public ICommand SignInCommand { get; }
    #endregion

    #region Private Methods
    private void TogglePassordButton()
    {
        if (EntryAsPassword)
            PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
        else
            PasswordIconCode = FontHelper.OPEN_EYE_ICON;

        EntryAsPassword = !EntryAsPassword;
    }

    private void SignIn()
    {
        SignInMessageVisible = true;
        if (_db.IsExist(UserName, UserPassword))
        {
            LoginMessage = AppMessages.SignInMessageSuccess;
            SignInMessageColor = Colors.Green;
        }
        else
        {
            LoginMessage = AppMessages.SignMessageFail;
            SignInMessageColor = Colors.Red;
        }
    }
    #endregion

    #region Public Properties
    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName != value)
            {
                _userName = value;
                OnPropertyChanged();
                (SignInCommand as Command)?.ChangeCanExecute();
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
                (SignInCommand as Command)?.ChangeCanExecute();
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

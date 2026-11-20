using AppProject.Models;

namespace AppProject.Services;

public class DBMokup
{
    private readonly List<AppUser> _users = new();

    public DBMokup()
    {
        _users.Add(new AppUser { UserEmail = "admin@mail.com", UserPassword = "admin" });
        _users.Add(new AppUser { UserEmail = "user1@mail.com", UserPassword = "pass1" });
        _users.Add(new AppUser { UserEmail = "user2@mail.com", UserPassword = "pass2" });
    }

    public bool IsExist(string? uEmail, string? uPass)
    {
        return _users.Any(u => u.UserEmail == uEmail && u.UserPassword == uPass);
    }
}


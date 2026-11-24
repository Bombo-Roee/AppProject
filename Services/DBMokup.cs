using AppProject.Models;

namespace AppProject.Services;

public class DBMokup
{
    private readonly List<AppUser> _users = new();

    public DBMokup()
    {
        _users.Add(new AppUser { FirstName = "Admin", LastName = "User", UserEmail = "admin@mail.com", UserPassword = "admin", Mobile = "0501234567" });
        _users.Add(new AppUser { FirstName = "User", LastName = "One", UserEmail = "user1@mail.com", UserPassword = "pass1", Mobile = "0501234568" });
        _users.Add(new AppUser { FirstName = "User", LastName = "Two", UserEmail = "user2@mail.com", UserPassword = "pass2", Mobile = "0501234569" });
    }

    public bool IsExist(string? uEmail, string? uPass)
    {
        return _users.Any(u => u.UserEmail == uEmail && u.UserPassword == uPass);
    }

    public void Add(AppUser user)
    {
        _users.Add(user);
    }

    public List<AppUser> GetAllUsers() => _users;
}

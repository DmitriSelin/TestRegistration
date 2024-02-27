using TestRegistration.Web.Models;

namespace TestRegistration.Web.Data;

public static class ApplicationMemoryUserList
{
    private static readonly List<User> _users = new();

    public static void Add(User newUser)
    {
        _users.Add(newUser);
    }

    public static User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(x => x.Email == email);
    }

    public static User? GetUserById(Guid userId)
    {
        return _users.FirstOrDefault(x => x.Id == userId);
    }
}
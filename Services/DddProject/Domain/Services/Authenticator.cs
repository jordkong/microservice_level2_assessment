namespace DddProject.Domain.Services;
using DddProject.Domain.Entities;

public class Authenticator : IAuthenticator
{
    public bool Authenticate(User user)
    {
        return user.Username == "admin" && user.Password == "admin";
    }
}
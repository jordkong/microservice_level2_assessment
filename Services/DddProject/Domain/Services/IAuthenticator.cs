namespace DddProject.Domain.Services;
using DddProject.Domain.Entities;

public interface IAuthenticator
{
    bool Authenticate(User user);
}
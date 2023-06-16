using CinemaApp.Models;

namespace CinemaApp.Repository
{
    public interface IAccountRepository
    {
        void Create(string username, string password);
        Account Read(string username);
    }
}
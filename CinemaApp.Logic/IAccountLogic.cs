using CinemaApp.Models;

namespace CinemaApp.Logic
{
    public interface IAccountLogic
    {
        void CreateUser(string username, string password);
        Account ReadUser(string username);
    }
}
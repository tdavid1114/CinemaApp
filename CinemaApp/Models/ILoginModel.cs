using Castle.Components.DictionaryAdapter;
using System.Collections.ObjectModel;

namespace CinemaApp.Models
{
    public interface ILoginModel
    {
        void ChangeStatusLoggedIn();

        bool IsLoginSuccessful(string username, string password);

        void IsRegistrationSuccessful(string username, string password, string confirmpassword, ObservableCollection<string> Errors);
    }
}
namespace CinemaApp.Models
{
    public interface INavBarModel
    {
        void changeStatusLoggedOut();
        void NavigateToLogin();
        void NavigateToMyTickets();
    }
}
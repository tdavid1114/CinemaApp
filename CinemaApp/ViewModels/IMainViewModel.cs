using GalaSoft.MvvmLight;

namespace CinemaApp.ViewModels
{
    public interface IMainViewModel
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
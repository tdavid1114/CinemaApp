using GalaSoft.MvvmLight;

namespace CinemaApp.ViewModels
{
    public class MainViewModel : ObservableObject, IMainViewModel
    {
        private static readonly MainViewModel mainViewModel = new MainViewModel();

        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { Set(ref currentViewModel, value); }
        }

        private ViewModelBase navBarViewModel;

        public ViewModelBase NavBarViewModel
        {
            get { return navBarViewModel; }
            set { Set(ref navBarViewModel, value); }
        }

        public static MainViewModel GetMainViewModel()
        {
            return mainViewModel;
        }
    }
}
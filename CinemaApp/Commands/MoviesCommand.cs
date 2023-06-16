using CinemaApp.Models;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CinemaApp.Commands
{
    public class MoviesCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private IMessenger messenger;

        public MoviesCommand(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? screeningId)
        {
            this.messenger.Send("TicketsViewModel", "vmchange");
            this.messenger.Send((int)screeningId, "moviedata");
            this.messenger.Send("TicketsViewModel", "vmchange");
        }
    }
}
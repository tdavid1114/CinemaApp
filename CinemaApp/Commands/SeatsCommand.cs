using Castle.Components.DictionaryAdapter.Xml;
using CinemaApp.Models;
using CinemaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CinemaApp.Commands
{
    public class SeatsCommand : ICommand
    {
        private SeatsViewModel seatsViewModel;

        private List<int> Column;

        public SeatsCommand(SeatsViewModel seatsViewModel)
        {
            this.seatsViewModel = seatsViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string p = parameter as string;
            string[] positions = p.Split(',');
            int y = int.Parse(positions[0]);
            int x = int.Parse(positions[1]);

            if (seatsViewModel.SeatsToSelect != 0 || (seatsViewModel.SeatsToSelect == 0 && seatsViewModel.Seats_y[y][x] == 1))
            {
                switch (seatsViewModel.Seats_y[y][x])
                {
                    case 0:
                        seatsViewModel.Seats_y[y][x] = 1;
                        seatsViewModel.SeatsToSelect--;
                        if (seatsViewModel.Row.ContainsKey(y))
                        {
                            seatsViewModel.Row[y].Add(x);
                        }
                        else
                        {
                            Column = new List<int>();
                            Column.Add(x);
                            seatsViewModel.Row.Add(y, Column);
                        }
                        break;

                    case 1:
                        seatsViewModel.Seats_y[y][x] = 0;
                        seatsViewModel.SeatsToSelect++;
                        seatsViewModel.Row[y].Remove(x);
                        break;
                }
            }
        }
    }
}
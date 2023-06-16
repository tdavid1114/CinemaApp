using CinemaApp.Models;
using CinemaApp.Repository;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;

namespace CinemaApp.Logic
{
    public class SeatLogic : ISeatLogic
    {
        private ISeatRepository repository;

        public SeatLogic(ISeatRepository repository)
        {
            this.repository = repository;
        }

        public List<List<short>> ReadSeats(int screeningsId)
        {
            var seatsArray = this.repository
                .ReadAll()
                .Where(seats => seats.Screenings.Any(x => x.ScreeningId == screeningsId))
                .Select(seats => seats.AvailableSeats)
                .FirstOrDefault();

            if (seatsArray != null)
            {
                int rows = seatsArray.GetLength(0);
                int columns = seatsArray.GetLength(1);

                var resultList = new List<List<short>>();

                for (int i = 0; i < rows; i++)
                {
                    var rowList = new List<short>();
                    for (int j = 0; j < columns; j++)
                    {
                        rowList.Add(seatsArray[i, j]);
                    }
                    resultList.Add(rowList);
                }

                return resultList;
            }

            return null;
        }

        public void UpdateSeats(int row, int column, int screeningsId)
        {
            this.repository.Update(row, column, screeningsId);
        }
    }
}
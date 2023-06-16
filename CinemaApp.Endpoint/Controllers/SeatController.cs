using CinemaApp.Endpoint.Services;
using CinemaApp.Logic;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using static CinemaApp.Logic.SeatLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private ISeatLogic seatLogic;
        private IHubContext<SignalRHub> hub;

        public SeatController(ISeatLogic seatLogic, IHubContext<SignalRHub> hub)
        {
            this.seatLogic = seatLogic;
            this.hub = hub;
        }

        [HttpGet("{screeningsId}")]
        public List<List<short>> ReadSeats(int screeningsId)
        {
            return this.seatLogic.ReadSeats(screeningsId);
        }

        [HttpPut("{row}/{column}/{screeningsId}")]
        public void UpdateSeats(int row, int column, int screeningsId)
        {
            this.seatLogic.UpdateSeats(row, column, screeningsId);
            this.hub.Clients.All.SendAsync("SeatStatusChanged", row, column);
        }
    }
}
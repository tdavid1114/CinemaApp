using CinemaApp.Endpoint.Services;
using CinemaApp.Logic;
using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using static CinemaApp.Logic.MovieLogic;
using static CinemaApp.Logic.SeatLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaApp.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketLogic ticketLogic;
        private IHubContext<SignalRHub> hub;

        public TicketController(ITicketLogic ticketLogic, IHubContext<SignalRHub> hub)
        {
            this.ticketLogic = ticketLogic;
            this.hub = hub;
        }

        [HttpPost("{title}/{day}/{time}/{row}/{column}/{user}")]
        public void CreateTicket(string title, string day, string time, int row, int column, string user)
        {
            this.ticketLogic.CreateTicket(title, day, time, row, column, user);
        }

        [HttpGet("{currentuser}")]
        public IEnumerable<Ticket> ReadTicket(string currentuser)
        {
            return this.ticketLogic.ReadTicket(currentuser);
        }
    }
}
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
    public class AccountController : ControllerBase
    {
        private IAccountLogic accountLogic;
        private IHubContext<SignalRHub> hub;

        public AccountController(IAccountLogic accountLogic, IHubContext<SignalRHub> hub)
        {
            this.accountLogic = accountLogic;
            this.hub = hub;
        }

        [HttpGet("{username}")]
        public Account ReadUser(string username)
        {
            return this.accountLogic.ReadUser(username);
        }

        [HttpPost("{username}/{password}")]
        public void CreateUser(string username, string password)
        {
            this.accountLogic.CreateUser(username, password);
        }
    }
}
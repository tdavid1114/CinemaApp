using CinemaApp.Models;
using CinemaApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private IAccountRepository repository;

        public AccountLogic(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public Account ReadUser(string username)
        {
            return this.repository.Read(username);
        }

        public void CreateUser(string username, string password)
        {
            this.repository.Create(username, password);
        }
    }
}
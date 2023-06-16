using CinemaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private CinemaDBContext ctx;

        public AccountRepository(CinemaDBContext ctx)
        {
            this.ctx = ctx;
        }

        public Account Read(string username)
        {
            return (from account in ctx.Accounts
                    where account.Username == username
                    select account).FirstOrDefault();
        }

        public void Create(string username, string password)
        {
            Account acc = new Account();
            acc.Username = username;
            acc.Password = password;
            ctx.Accounts.Add(acc);
            ctx.SaveChanges();
        }
    }
}
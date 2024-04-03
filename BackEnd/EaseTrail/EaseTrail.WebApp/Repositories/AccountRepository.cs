using EaseTrail.WebApp.Interfaces;
using EaseTrail.WebApp.Models;
using EaseTrail.WebApp.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace EaseTrail.WebApp.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EaseTDbContext _context;

        public AccountRepository(EaseTDbContext context)
        {
            _context = context;
        }

        public async Task CreateAccount(Account account)
        {
            try
            {
                var existAccount = await _context.Accounts
                .Where(x => x.Email == account.Email)
                .Select(x => x.Email)
                .FirstOrDefaultAsync();

                if (existAccount != null)
                {
                    throw new Exception("User allready exists");
                }

                var verifyUser = new Account(account.Email, account.Password, account.Phone);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

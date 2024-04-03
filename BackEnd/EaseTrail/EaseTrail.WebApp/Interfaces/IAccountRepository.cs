using EaseTrail.WebApp.Models;

namespace EaseTrail.WebApp.Interfaces
{
    public interface IAccountRepository
    {
        public Task CreateAccount(Account account);
        public void Login(string email, string password);
    }
}

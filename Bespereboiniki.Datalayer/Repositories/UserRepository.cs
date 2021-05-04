using System.Linq;
using Bespereboiniki.Datalayer.Tables;
using Microsoft.EntityFrameworkCore;

namespace Bespereboiniki.Datalayer.Repositories
{
    public interface IUserRepository
    {
        User? GetUserByLogin(string login);
    }
    public class UserRepository: IUserRepository
    {
        private readonly UPSContext context;

        public UserRepository(UPSContext context)
        {
            this.context = context;
        }

        public User? GetUserByLogin(string login)
        {
            return context.Users.Include(user => user.UserRole).FirstOrDefault(user => user.Login == login);
        }
    }
}
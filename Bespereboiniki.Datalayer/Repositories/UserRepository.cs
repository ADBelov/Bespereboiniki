using System.Collections.Generic;
using System.Linq;
using Bespereboiniki.Datalayer.Tables;
using Microsoft.EntityFrameworkCore;

namespace Bespereboiniki.Datalayer.Repositories
{
    public interface IUserRepository
    {
        User? GetUserByLogin(string login);
        List<User> GetUsers(int skip, int take);
    }

    public class UserRepository : IUserRepository
    {
        private readonly UPSContext context;

        public UserRepository(UPSContext context)
        {
            this.context = context;
        }

        public List<User> GetUsers(int skip, int take)
        {
            return context.Users
                .Include(user => user.UserRole)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public User? GetUserByLogin(string login)
        {
            return context.Users
                .Include(user => user.UserRole)
                .FirstOrDefault(user => user.Login == login);
        }
    }
}
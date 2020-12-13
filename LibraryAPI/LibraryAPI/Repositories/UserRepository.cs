using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class UserRepository : Repository<User, string>
    {
        public UserRepository(LibraryContext context) : base(context) { }

        public User GetUserByCredentials(string username, string password)
        {
            return entities.SingleOrDefault(x => x.Username == username && x.Password == password);
        }

        public User GetById(string username)
        {
            return entities.SingleOrDefault(x => x.Username == username);
        }

    }
}

using SimpleExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExample.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> users = new List<User>() { new User() { Username = "Admin", Password = "Admin", Role = "Admin" } };
        public UserRepository()
        {

        }

        public User GetUser(string username, string password)
        {
            return users.FirstOrDefault(o => o.Username == username && o.Password == password);
        }

        public bool GetUser(string username, string password, out User user)
        {
            user = GetUser(username, password);
            return user != null;
        }

        public User GetUser(int userid)
        {
            return users.FirstOrDefault(o => o.Id == userid);

        }
    }
}

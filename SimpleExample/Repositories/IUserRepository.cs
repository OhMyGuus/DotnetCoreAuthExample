using System.Threading.Tasks;
using SimpleExample.Models;

namespace SimpleExample.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
        bool GetUser(string username, string password, out User user);
        User GetUser(int userid);
    }
}
using itcrafts.BL;
using itcrafts.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.DL.Interfaces
{
    public interface IUserDL
    {
        List<User> GetUsers();
        User? Authenticate(string username, string password);
        List<RoleType> GetUserRoles(int userId);
        bool AddUser(User user);
        bool DeleteUser(int userId);
        bool UpdateUser(int userId, string fullname, string username, string password);
        bool SetRoles(int userId, List<RoleType> roles);
    }
}

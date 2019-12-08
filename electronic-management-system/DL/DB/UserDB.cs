using itcrafts.BL;
using itcrafts.BL.Abstract;
using itcrafts.DL.General;
using itcrafts.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.DL.DB
{
    public class UserDB : IUserDL
    {
        public List<User> GetUsers()
        {
            return UserDL.CreateUsers(Utils.DB.GetTableInDataSet("User"));
        }

        public User? Authenticate(string username, string password)
        {
            Debug.WriteLine(username + password);
            var data = Utils.DB.ExecuteAndGetDataSet($"SELECT * FROM [User] WHERE Username='{username}' AND Password='{password}'");
            if (data.Count == 0) return null;
            var userData = data[0];
            var roles = Utils.DB.ExecuteAndGetDataSet($"SELECT * FROM [UserRole] WHERE UserId={userData["Id"]}");
            return new User(userData, roles);
        }

        public List<RoleType> GetUserRoles(int userId)
        {
            var data = Utils.DB.ExecuteAndGetDataSet($"SELECT Role FROM [UserRole] WHERE UserId={userId}");
            return data.Select(d => (RoleType)d["Role"]!).ToList();
        }

        public bool AddUser(User user)
        {
            try
            {
                Utils.DB.Execute($"INSERT INTO [User] (Fullname, Username, Password) VALUES ('{user.GetFullname()}', '{user.GetUsername()}', '{user.GetPassword()}')");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateUser(int userId, string fullname, string username, string password)
        {
            try
            {
                Utils.DB.Execute($"UPDATE [User] SET Fullname='{fullname}', Username='{username}', Password='{password}' WHERE Id={userId}");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                Utils.DB.Execute($"DELETE FROM [User] WHERE Id={userId}");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SetRoles(int userId, List<RoleType> roles)
        {
            // Make sure user exists
            var users = GetUsers();
            var user = users.Find(u => u.GetId() == userId);
            if (user == null) return false;
            // Delete all roles first
            Utils.DB.Execute($"DELETE FROM [UserRole] WHERE UserId={userId}");
            // Replace with new roles
            foreach (RoleType role in roles)
            {
                Utils.DB.Execute($"INSERT INTO [UserRole] (UserId, Role) VALUES ({userId}, {(int) role})");
            }
            return true;
        }
    }
}

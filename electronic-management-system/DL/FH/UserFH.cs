using itcrafts.BL;
using itcrafts.BL.Abstract;
using itcrafts.DL.General;
using itcrafts.DL.Interfaces;
using itcrafts.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.DL.FH
{
    public class UserFH : IUserDL
    {
        public List<User> GetUsers()
        {
            return UserDL.CreateUsers(Utils.FH.LoadData("User", User.GetSchema()));
        }

        public User? Authenticate(string username, string password)
        {
            var users = GetUsers();
            var user = users.Find(user => user.GetPassword() == password && user.GetUsername() == username);
            return user;
        }

        public List<RoleType> GetUserRoles(int userId)
        {
            var roles = Utils.FH.LoadData("UserRole", Role.GetSchema());
            var rolesList = roles
                .FindAll(r => (int)r["UserId"]! == userId)
                .Select(r => (RoleType)r["Role"]!)
                .ToList();
            return rolesList;
        }

        public bool AddUser(User user)
        {
            var users = Utils.FH.LoadData("User", User.GetSchema());
            var existingUser = users.Find(u => (string)u["Username"]! == user.GetUsername());
            if (existingUser != null) return false;
            var userDict = new Dictionary<string, object?>
            {
                ["Id"] = Utils.FH.GetUniqueId(),
                ["Fullname"] = user.GetFullname(),
                ["Username"] = user.GetUsername(),
                ["Password"] = user.GetPassword(),
                ["DateCreated"] = user.GetDateCreated()
            };
            users.Add(userDict);
            Utils.FH.SaveData("User", users);
            return true;
        }

        public bool UpdateUser(int userId, string fullname, string username, string password)
        {
            var users = Utils.FH.LoadData("User", User.GetSchema());
            var userWithUsername = users.Find(u => (string)u["Username"]! == username);
            if (userWithUsername != null) return false;
            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                if ((int) user["Id"]! == userId)
                {
                    users[i]["Fullname"] = fullname;
                    users[i]["Username"] = username;
                    users[i]["Password"] = password;
                }
            }
            Utils.FH.SaveData("User", users);
            return true;
        }

        public bool DeleteUser(int userId)
        {
            var users = Utils.FH.LoadData("User", User.GetSchema());
            var userToRemove = users.Find(u => (int)u["Id"]! == userId);
            if (userToRemove == null) return false; 
            users.Remove(userToRemove);
            Utils.FH.SaveData("User", users);
            return true;
        }

        public bool SetRoles(int userId, List<RoleType> roles)
        {
            Debug.WriteLine("Have to add: " + roles.Count);
            var users = GetUsers();
            var user = users.Find(u => u.GetId() == userId);
            if (user == null) return false;
            // Remove all existing roles
            var table = Utils.FH.LoadData("UserRole", Role.GetSchema());
            int removed = table.RemoveAll(u => (int)u["UserId"]! == userId);
            Debug.WriteLine("Removed : " + removed);
            // Add new roles
            foreach (var role in roles)
            {
                table.Add(new Dictionary<string, object?>()
                {
                    ["Id"] = Utils.FH.GetUniqueId(),
                    ["UserId"] = userId,
                    ["role"] = (int)role
                });
            }
            Utils.FH.SaveData("UserRole", table);
            return true;
        }
    }
}

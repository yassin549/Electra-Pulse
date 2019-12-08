using itcrafts.BL;
using itcrafts.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace itcrafts.DL.General
{
    public class UserDL
    {
        public static List<User> CreateUsers(List<Dictionary<string, object?>> dataSet)
        {
            var usersList = new List<User>();
            foreach (var data in dataSet)
            {
                var user = new User(
                    (int)data["Id"]!,
                    (string)data["Fullname"]!,
                    (string)data["Username"]!,
                    (string)data["Password"]!,
                    (DateTime)data["DateCreated"]!
                );
                usersList.Add(user);
            }
            return usersList;
        }
    }
}

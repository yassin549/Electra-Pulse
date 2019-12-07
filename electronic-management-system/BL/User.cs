using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    public class User
    {
        protected int Id;
        protected string Fullname;
        protected string Username;
        protected string Password;
        protected DateTime DateCreated;

        public int GetId() { return Id; }
        public string GetFullname() { return Fullname; }
        public string GetUsername() { return Username; }
        public string GetPassword() { return Password; }
        public DateTime GetDateCreated() { return DateCreated; }

        public User(int id, string fullname, string username, string password, DateTime dateCreated)
        {
            Id = id;
            Fullname = fullname;
            Username = username;
            Password = password;
            DateCreated = dateCreated;
        }

        public User(Dictionary<string, object?> user, List<Dictionary<string, object?>> roles)
        {
            Id = (int)user["Id"]!;
            Fullname = (string)user["Fullname"]!;
            Username = (string)user["Username"]!;
            Password = (string)user["Password"]!;
            DateCreated = (DateTime)user["DateCreated"]!;
        }

        static (string[], Type[]) Schema = (
            ["Id", "Fullname", "Username", "Password", "DateCreated"],
            [typeof(int), typeof(string), typeof(string), typeof(string), typeof(DateTime)]
        );

        public static (string[], Type[]) GetSchema()
        {
            return Schema;
        }

        public static bool IsValidFullname(string fullname)
        {
            return Regex.IsMatch(fullname, @"^[a-zA-Z\s]{3,25}$");
        }

        public static string GetFullnameError()
        {
            return "Fullname must contain only alphabets and spaces";
        }

        public static bool IsValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9_]{3,20}$");
        }

        public static string GetUsernameError()
        {
            return "Username must contain only alphanumeric and underscores";
        }

        public static bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*\W).{8,25}$");
        }

        public static string GetPasswordError()
        {
            return "Password must be 8+, have one alphabet, digit and symbol atleast";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    public class Supplier
    {
        public int Id;
        public string Name;
        public string About;
        public string Email;
        public string Phone;

        public Supplier(int id, string name, string about, string email, string phone)
        {
            Id = id;
            Name = name;
            About = about;
            Email = email;
            Phone = phone;
        }
    }
}

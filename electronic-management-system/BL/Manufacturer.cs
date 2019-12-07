using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    internal class Manufacturer
    {
        public int Id;
        public string Name;
        public string Address;
        public string Email;
        public string Phone;

        public Manufacturer(int id, string name, string address, string email, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAProject
{
    public class Guest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Guest(string name, string email, string phoneNumber, string address)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }
}

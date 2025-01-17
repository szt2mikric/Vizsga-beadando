using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtthonBerles.Models
{
    public class Customer
    {

        public Customer(string id, string fullName, string email, string password)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);
            

            Id = id_;
            FullName = fullName;
            Email = email;
            Password = password;
           
        }

        public Customer(int id, string fullName, string email, string password)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
        }

        private int id;
        private string fullname;
        private string email;
        private string password;

        public string FullName { get => fullname; set => fullname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return FullName + " " + email + " : " + Id.ToString();
        }

    }
}

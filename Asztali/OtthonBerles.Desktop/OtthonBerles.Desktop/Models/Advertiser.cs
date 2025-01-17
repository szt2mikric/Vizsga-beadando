using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtthonBerles.Models
{
    public class Advertiser
    {
        public Advertiser(string id, string fullname, string email, string password, string companyname)
        {
            int id_ = 0;
            Int32.TryParse(id, out id_);

            Id = id_;
            FullName = fullname;
            Email = email;
            Password = password;
            CompanyName = companyname;
        }

        public Advertiser(int id, string fullname, string email, string password, string companyname)
        {
            Id = id;
            FullName = fullname;
            Email = email;
            Password = password;
            CompanyName = companyname;
        }

        private int id;
        private string fullname;
        private string email;
        private string password;
        private string companyname;

        public int Id { get => id; set => id = value; }
        public string FullName { get => fullname; set => fullname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string CompanyName { get => companyname; set => companyname = value; }


        public override string ToString()
        {
            return FullName + " : " + Id.ToString();
        }
    }
}

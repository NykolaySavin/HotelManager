using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    public class InternalUserData : Base<InternalUserData>
    {
        public InternalUserData(string username, string email, string hashedPassword, string role)
        {
            Username = username;
            Email = email;
            HashedPassword = hashedPassword;
            Role = role;
        }
        public InternalUserData()
        {

        }
        public string Username
        {
            get;
            set;
        }
        public Employee Employee
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }

        public string HashedPassword
        {
            get;
            set;
        }

        public string Role
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    public class Employee
    {
        public Employee(string username, string email, string role)
        {
            Username = username;
            Email = email;
            Role = role;
        }
        public Employee()
        {

        }
        [Key]
        public string Username
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }

        public string Role
        {
            get;
            set;
        }
        public InternalUserData User { get; set; }
    }
}

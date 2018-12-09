using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.OrderDirectory
{
    public class Client : Person
    {
        public Client(string name, string surname, string phone ,string email) : base(name, surname, email, phone)
        {

        }
    }
}

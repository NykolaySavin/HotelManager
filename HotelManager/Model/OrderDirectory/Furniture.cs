using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.OrderDirectory
{
    public class Furniture:Base
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public  Room Room { get; set; }
        

    }
}

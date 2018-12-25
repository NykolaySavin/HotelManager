using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace HotelManager.ViewModel
{
    public class AdminViewModel
    {
        [Dependency]
        public RoomViewModel RoomViewModel
        {
            get; set;
        }
    }
}

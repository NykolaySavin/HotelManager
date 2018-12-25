using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace HotelManager.ViewModel
{
    public class AdminViewModel
    {
        DbContext context;
        public AdminViewModel(DbContext context,RoomViewModel roomViewModel)
        {
            this.context = context;
            RoomViewModel = roomViewModel;
            
        }
      
        public RoomViewModel RoomViewModel
        {
            get; set;
        }
    }
}

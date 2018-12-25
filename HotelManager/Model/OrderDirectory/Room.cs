using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.OrderDirectory
{
    public class Room : Base
    {
        public string Number { get; set; }
        public virtual ICollection<Furniture> Furniture { get; set; }
        public RoomState State { get; set; }
        public Room()
        {
            Furniture = new List<Furniture>();
        }
        public override string ToString()
        {
            return Number;
        }
    }

    public enum RoomState
    {
        [Description("Free")]
        Free,
        [Description("Preparing")]
        Preparing,
        [Description("Occupied")]
        Occupied
    }
}

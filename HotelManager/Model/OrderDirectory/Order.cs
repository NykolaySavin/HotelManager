using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.OrderDirectory
{
    public class Order
    {
        [Key, ForeignKey("Client")]
        [Column(Order = 0)]
        public int ClientId { get; set; }

        [Key, ForeignKey("Room")]
        [Column(Order = 1)]
        public int RoomId { get; set; }
        [Column(Order =2)]
        [Key, ForeignKey("ServiceType")]
        public int ServiceTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public double Sum { get; set; }

        public Client Client { get; set; }
        public Room Room { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}

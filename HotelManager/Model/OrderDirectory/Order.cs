using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.OrderDirectory
{
    public class Order : Base<Order>
    {
        [Key, ForeignKey("Client")]
        [Column(Order = 1)]
        public Guid ClientId { get; set; }

        [Key, ForeignKey("Room")]
        [Column(Order =2)]
        public Guid RoomId { get; set; }
        [Column(Order =3)]
        [Key, ForeignKey("ServiceType")]
        public Guid ServiceTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public double Sum { get; set; }

        public Client Client { get; set; }
        public Room Room { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}

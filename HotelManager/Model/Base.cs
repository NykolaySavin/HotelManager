using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model
{
    public class Base<T> where T:Base<T>
    {
        public static Dictionary<Guid, T> Items = new Dictionary<Guid, T>();
        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }
        public Base()
        {
            Id = Guid.NewGuid();
            Items.Add(Id, (T)this);
        }
    }
}

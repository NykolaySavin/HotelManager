using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.OrderDirectory
{
    public class Service : Base
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public  ICollection<ServiceType> ServiceTypes { get; set; }
        public Service()
        {
            ServiceTypes = new List<ServiceType>();
            Employees = new List<Employee>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

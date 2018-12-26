﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.OrderDirectory
{
    public class Service : Base
    {
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public virtual List<ServiceType> ServiceTypes { get; set; }
        public Service()
        {
            Employees = new List<Employee>();
            ServiceTypes = new List<ServiceType>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

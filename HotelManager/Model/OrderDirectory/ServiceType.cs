﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.OrderDirectory
{
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Service> Services { get; set; }
        public ServiceType()
        {
            Services = new List<Service>();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.OrderDirectory
{
    public class Furniture:Base<Furniture>
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
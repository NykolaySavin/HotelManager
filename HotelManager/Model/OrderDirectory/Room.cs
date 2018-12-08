﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Model.OrderDirectory
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Furniture> Furniture { get; set; }
        public RoomState State { get; set; }
        public Room()
        {
            Furniture = new List<Furniture>();
        }
    }
    public enum RoomState
    {
        Free,
        Preparing,
        Occupied
    }
}

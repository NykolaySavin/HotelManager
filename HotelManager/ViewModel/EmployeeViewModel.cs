﻿using HotelManager.Model.Context;
using HotelManager.Model.Services;
using HotelManager.ViewModel.Autorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.ViewModel
{
    public class EmployeeViewModel : IViewModel
    {
        public IRoomService RoomService { get;  }
        public EmployeeViewModel(IRoomService roomService)
        {
            RoomService = roomService;
        }
        public string Text { get { return "DFSfd"; }  }
    }
}

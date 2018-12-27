using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace HotelManager.ViewModel
{
    public class AdminViewModel
    {
        DbContext context;
        public AdminViewModel(DbContext context,RoomViewModel roomViewModel, ServiceTypeViewModel serviceTypeViewModel, EmployeeViewModel employeeViewModel)
        {
            this.context = context;
            EmployeeViewModel = employeeViewModel;
            RoomViewModel = roomViewModel;
            ServiceTypeViewModel = serviceTypeViewModel;
        }
        public void Update()
        {
            RoomViewModel.OnUpdate(null, null);
            ServiceTypeViewModel.OnUpdate(null, null);
            EmployeeViewModel.OnUpdate(null, null);
        }
        public RoomViewModel RoomViewModel
        {
            get; set;
        }
        public ServiceTypeViewModel ServiceTypeViewModel
        {
            get; set;
        }
        public EmployeeViewModel EmployeeViewModel
        {
            get; set;
        }
    }
}

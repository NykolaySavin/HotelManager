using HotelManager.Model.Context;
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
        public HotelContext OrderContext { get;  }
        public EmployeeViewModel(HotelContext context)
        {
            OrderContext = context;
        }
    }
}

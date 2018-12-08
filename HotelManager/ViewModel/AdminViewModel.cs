using HotelManager.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.ViewModel
{
    public class AdminViewModel : EmployeeViewModel
    {
        public AdminViewModel(IDataContext orderContext):base(orderContext)
        {

        }
    }
}

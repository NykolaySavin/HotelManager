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
        public IDataContext DataContext { get;  }
        public EmployeeViewModel(IDataContext context)
        {
            DataContext = context;
        }
    }
}

using HotelManager.Model.Autorization;
using HotelManager.Model.Context;
using HotelManager.ViewModel;
using HotelManager.ViewModel.Autorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HotelManager.View
{
    public class Pages
    {
        private static HotelContext orderContext;
        private static AdminControl adminControl;
        public static AdminControl AdminControl
        {
            get
            {
                if (orderContext == null)
                {
                    orderContext = new HotelContext();
                }
                AdminViewModel adminViewModel = new AdminViewModel(orderContext);
                adminControl = new AdminControl(adminViewModel);
                return adminControl;
            }
        }
        private static LoginControl loginControl;
        public static LoginControl LoginControl
        {
            get
            {
                AuthenticationViewModel viewModel = new AuthenticationViewModel(new AuthenticationService());
                loginControl = new LoginControl(viewModel);
                return loginControl;
            }
        }
        private static EmployeeControl employeeControl;
        public static EmployeeControl EmployeeControl
        {
            get
            {

                if (orderContext == null)
                {
                    orderContext = new HotelContext();
                }
                EmployeeViewModel employeeViewModel = new EmployeeViewModel(orderContext);
                employeeControl = new EmployeeControl(employeeViewModel);
                return employeeControl;
            }
        }
        public static void SetPage(UserControl control)
        {
            (App.Current.MainWindow as Main).SetPage(control);
        }
    }
}

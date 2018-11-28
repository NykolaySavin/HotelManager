using HotelManager.Model.Autorization;
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
        private static AdminControl adminControl;
        public static AdminControl AdminControl
        {
            get
            {
                adminControl = new AdminControl();
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

                employeeControl = new EmployeeControl();
                return employeeControl;
            }
        }
        public static void SetPage(UserControl control)
        {
            (App.Current.MainWindow as Main).SetPage(control);
        }
    }
}

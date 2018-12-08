using HotelManager.Model.Autorization;
using HotelManager.Model.Context;
using HotelManager.Model.Services;
using HotelManager.ViewModel;
using HotelManager.ViewModel.Autorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Unity;

namespace HotelManager.View
{
    public class Pages
    {
        private static IUnityContainer container;
        static Pages()
        {
            container = new UnityContainer();
            container.RegisterType<IRoomService, RoomService>();
        }
        private static HotelContext orderContext;
        private static AdminControl adminControl;
        public static AdminControl AdminControl
        {
            
            get
            {
                AdminViewModel adminViewModel = container.Resolve<AdminViewModel>();
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
                EmployeeViewModel employeeViewModel = container.Resolve<EmployeeViewModel>();
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

using HotelManager.Model.Autorization;
using HotelManager.Model.Context;
using HotelManager.Model.OrderDirectory;
using HotelManager.Model.Services;
using HotelManager.ViewModel;
using HotelManager.ViewModel.Autorization;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Unity;
using Unity.Injection;

namespace HotelManager.View
{
    public class Pages
    {
        private static IUnityContainer container;
        private static Main main; 
        static Pages()
        {
            container = new UnityContainer();
            main = App.Current.MainWindow as Main;
            //container.RegisterType<IService<Room>, RoomService>();
            //container.RegisterType<RoomViewModel, RoomViewModel>();
            //container.RegisterType<FurnitureViewModel, FurnitureViewModel>();
           // container.RegisterType<IService<Furniture>, FurnitureService>();
        }
        private static AdminControl adminControl;
        public static AdminControl AdminControl
        {
            
            get
            {
                // AdminViewModel adminViewModel = container.Resolve<AdminViewModel>();
                //container.RegisterType<DbContext, HotelContext>();
                HotelContext context = new HotelContext();
                container.RegisterType<IService<Furniture>, FurnitureService>(new InjectionConstructor(context));
                container.RegisterType<IService<Room>, RoomService>(new InjectionConstructor(context ));
               


                container.RegisterType<AdminViewModel>(new InjectionConstructor(new object[] {context, container.Resolve<RoomViewModel>() }));
                //AdminViewModel viewmodel = container.Resolve<AdminViewModel>();
                container.RegisterType<AdminControl>();
                adminControl = container.Resolve<AdminControl>();
                main.Width = 1200;
                main.Height = 800;
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
                //EmployeeViewModel employeeViewModel = container.Resolve<EmployeeViewModel>();
                employeeControl = container.Resolve<EmployeeControl>();
                main.Width = 800;
                main.Height = 450;
                return employeeControl;
            }
        }
      
        public static void SetPage(UserControl control)
        {
            main.SetPage(control);
        }
        public static void SetRoomPage(UserControl control)
        {
            adminControl.roomPage.Content=control;
        }
    }
}

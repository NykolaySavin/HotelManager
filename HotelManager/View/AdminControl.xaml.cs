using HotelManager.ViewModel;
using HotelManager.ViewModel.Autorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity.Attributes;

namespace HotelManager.View
{
    /// <summary>
    /// Логика взаимодействия для AdminControl.xaml
    /// </summary>
    /// 
    [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
    public partial class AdminControl : UserControl
    {
        public AdminControl(AdminViewModel adminViewModel)
        {
            InitializeComponent();
            ViewModel = adminViewModel;
        }
        public AdminViewModel ViewModel
        {
            set { DataContext = value; }
        }
    }
}

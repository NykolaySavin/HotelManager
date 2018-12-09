using HotelManager.ViewModel;
using HotelManager.ViewModel.Autorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
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

namespace HotelManager.View
{
    /// <summary>
    /// Логика взаимодействия для LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl(AuthenticationViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }
        public AuthenticationViewModel ViewModel
        {
            get { return DataContext as AuthenticationViewModel; }
            set { DataContext = value; }
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.IsActive = true;
            this.InvalidateVisual();
        }
    }
}

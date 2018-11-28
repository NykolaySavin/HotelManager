using HotelManager.Model.Autorization;
using HotelManager.ViewModel.Autorization;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManager.View
{
    public interface IView
    {
        IViewModel ViewModel
        {
            get;
            set;
        }
    }
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>

    public partial class Main : MetroWindow, IView 
    {
        public Main()
        {
            InitializeComponent();
           
        }
        public void SetPage(UserControl page)
        {
            this.Content = page;
        }
        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
            set { DataContext = value; }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            SetPage(Pages.LoginControl);
        }
    }
}

﻿using HotelManager.Model.Autorization;
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

    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>

    public partial class Main : MetroWindow
    {
        public Main()
        {
            InitializeComponent();
           
        }
        public void SetPage(UserControl page)
        {
            this.Content = page;
        }


        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            SetPage(Pages.LoginControl);
        }
    }
}

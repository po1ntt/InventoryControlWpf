﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для DepartamentPage.xaml
    /// </summary>
    public partial class DepartamentPage : Page
    {
        public DepartamentPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new HomePage());

        }
    }
}

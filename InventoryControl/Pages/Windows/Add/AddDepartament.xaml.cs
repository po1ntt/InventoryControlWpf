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
using System.Windows.Shapes;
using InventoryControl.Service;

namespace InventoryControl.Pages.Windows.Add
{
    /// <summary>
    /// Логика взаимодействия для AddDepartament.xaml
    /// </summary>
    public partial class AddDepartament : Window
    {
        public AddDepartament()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = DepartamentService.AddDepartament(namedep.Text);
            MessageBox.Show(result);
        }
    }
}

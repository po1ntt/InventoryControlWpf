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

namespace InventoryControl.Pages.Windows.Add
{
    /// <summary>
    /// Логика взаимодействия для AddTypeEquipment.xaml
    /// </summary>
    public partial class AddTypeEquipment : Window
    {
        public AddTypeEquipment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = Service.TypeEquipmentService.AddTypeEquipment(typeEquip.Text);
            MessageBox.Show(result);
        }
    }
}

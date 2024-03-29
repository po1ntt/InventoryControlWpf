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
using InventoryControl.BdWork;
using InventoryControl.Service;

namespace InventoryControl.Pages.Windows.Edit
{
    /// <summary>
    /// Логика взаимодействия для EditTypeEquipment.xaml
    /// </summary>
    public partial class EditTypeEquipment : Window
    {
        public TypeOfEquipment type;
        public EditTypeEquipment(TypeOfEquipment typeOfEquipment)
        {
            InitializeComponent();
            type = typeOfEquipment;
            txbType.Text = type.NameTypeEquip;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = TypeEquipmentService.EditTypeOf(type, txbType.Text);
            MessageBox.Show(result);
        }
    }
}

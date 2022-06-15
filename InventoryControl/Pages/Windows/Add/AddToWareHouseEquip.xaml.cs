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
using InventoryControl.Service;
using InventoryControl.BdWork;

namespace InventoryControl.Pages.Windows.Add
{
    /// <summary>
    /// Логика взаимодействия для AddToWareHouseEquip.xaml
    /// </summary>
    public partial class AddToWareHouseEquip : Window
    {
        public AddToWareHouseEquip()
        {
            InitializeComponent();
            EquipmentCombo.ItemsSource = Service.EquipmentService.GetEquipmentInfo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var equipment = EquipmentCombo.SelectedItem as Equipment;
            string result = Service.WarehouseEquipService.AddNewEquipmentToWarehouse(equipment.id_equip, Convert.ToInt32(txbCount.Text));
            MessageBox.Show(result);
        }
    }
}

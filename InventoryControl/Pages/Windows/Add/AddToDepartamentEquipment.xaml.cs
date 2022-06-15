using InventoryControl.BdWork;
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

namespace InventoryControl.Pages.Windows.Add
{
    /// <summary>
    /// Логика взаимодействия для AddToDepartamentEquipment.xaml
    /// </summary>
    public partial class AddToDepartamentEquipment : Window
    {
        
        public AddToDepartamentEquipment(WarehouseEquipment warehouse)
        {
            InitializeComponent();
            nameteh.Text = warehouse.Equipment.name;
            kolvoteh.Text = $"Кол-во на складе: {warehouse.count}";
            ComboDep.ItemsSource = Service.DepartamentService.GetDepartamentInfo();
            warehouse1 = warehouse;
        }
        public static WarehouseEquipment warehouse1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dep = ComboDep.SelectedItem as Departament;
            string result = Service.EquipmentDepartamentService.addDepartamentEquipment(warehouse1.Equipment.id_equip, dep.id_departament, Convert.ToInt32(txbCount.Text));
            MessageBox.Show(result);
        }
    }
}

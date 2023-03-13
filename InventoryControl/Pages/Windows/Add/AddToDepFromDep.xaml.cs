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
    /// Логика взаимодействия для AddToDepFromDep.xaml
    /// </summary>
    public partial class AddToDepFromDep : Window
    {
        public AddToDepFromDep(Departament departament)
        {
            InitializeComponent();
            departament1 = departament;
            EquipmentCombo.ItemsSource = Service.EquipmentService.GetEquipmentInfo();

        }
        public static Departament departament1;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var equip = EquipmentCombo.SelectedItem as Equipment;
            string result = Service.EquipmentDepartamentService.addDepartamentEquipment(equip.id_equip, departament1.id_departament, Convert.ToInt32(txbCount.Text));
            MessageBox.Show(result);
        }

        private void EquipmentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var equip = EquipmentCombo.SelectedItem as Equipment;
            var warehouseequip = context.WarehouseEquipment.FirstOrDefault(p => p.Equipment.id_equip == equip.id_equip) as WarehouseEquipment;
            nameteh.Text = warehouseequip.Equipment.name;
            kolvoteh.Text = $"Кол-во на складе: {warehouseequip.count}";
        }
    }
}

using InventoryControl.BdWork;
using InventoryControl.Service;
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

namespace InventoryControl.Pages.Windows.Edit
{
    /// <summary>
    /// Логика взаимодействия для EditEquipment.xaml
    /// </summary>
    public partial class EditEquipment : Window
    {
        public Equipment equipment1;
        public EditEquipment(Equipment equipment)
        {
            InitializeComponent();
            equipment1 = equipment;
            int selected_id_brand = (int)(equipment1.id_brand - 1);
            int selected_id_type = (int)(equipment1.typeofequipment_id- 1);
            BrandCombo.ItemsSource = BrandService.GetBrandInfo();
            TypeCombo.ItemsSource = TypeEquipmentService.GetTypeOfEquipmentInfo();
            BrandCombo.SelectedIndex = selected_id_brand;
            TypeCombo.SelectedIndex = selected_id_type;
            txbNameEquip.Text = equipment1.name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = EquipmentService.EditEquipment(equipment1, BrandCombo.SelectedItem as Brand, TypeCombo.SelectedItem as TypeOfEquipment, txbNameEquip.Text);
            MessageBox.Show(result);
        }
    }
}

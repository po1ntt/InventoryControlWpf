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
    /// Логика взаимодействия для AddEquipment.xaml
    /// </summary>
    public partial class AddEquipment : Window
    {
        public AddEquipment()
        {
            InitializeComponent();
            BrandSelected.ItemsSource = BrandService.GetBrandInfo();
            TypeTech.ItemsSource = TypeEquipmentService.GetTypeOfEquipmentInfo();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(BrandSelected.SelectedItem != null && TypeTech.SelectedItem != null)
            {
                var brand = BrandSelected.SelectedItem as Brand;
                var typetech = TypeTech.SelectedItem as TypeOfEquipment;
                string result = Service.EquipmentService.addEquipment(NameEquip.Text, brand.id_brand, typetech.id_typeEquip);
                MessageBox.Show(result);

            }
        }
    }
}

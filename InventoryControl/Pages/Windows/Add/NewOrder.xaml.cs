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
    /// Логика взаимодействия для NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Window
    {
        public NewOrder()
        {
            InitializeComponent();
            comboequip.ItemsSource = Service.EquipmentService.GetEquipmentInfo();
            comboseller.ItemsSource = Service.SellerService.GetSellerInfo();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var equip = comboequip.SelectedItem as BdWork.Equipment;
            var seller = comboseller.SelectedItem as BdWork.Seller;
            string result = Service.OrdersService.addOrder(Convert.ToInt32(countteh.Text), equip.id_equip, seller.id_seller, Convert.ToInt32(price.Text));
            MessageBox.Show(result);
        }
    }
}

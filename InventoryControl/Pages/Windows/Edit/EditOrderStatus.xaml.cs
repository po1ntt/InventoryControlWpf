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
    /// Логика взаимодействия для EditOrderStatus.xaml
    /// </summary>
    public partial class EditOrderStatus : Window
    {
        public static Orders orders1;
        public EditOrderStatus(Orders order)
        {
            InitializeComponent();
            orders1 = order;
            txbBrand.ItemsSource = StatusService.GetStatusInfo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InventoryСontrolEntities entities = new InventoryСontrolEntities();
            var orders = entities.Orders.Where(p => p.id_orders == orders1.id_orders).FirstOrDefault();
            var status = txbBrand.SelectedItem as Status;
            if(status.status1 == "Ожидается доставка")
            {
                MessageBox.Show("нельзя снова ставить статус ожидается доставка!");
            }
            else
            {
                orders.id_status = status.id_status;
                orders.DateOver = DateTime.Now;
                MessageBox.Show("Статус успешно изменен");
                entities.SaveChanges();
                  
            }
            
        }
    }
}

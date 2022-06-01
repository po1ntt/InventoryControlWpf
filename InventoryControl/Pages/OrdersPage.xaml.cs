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
using System.Windows.Navigation;
using System.Windows.Shapes;
using InventoryControl.Service;
using InventoryControl.BdWork;

namespace InventoryControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            WareHouseEquipDG.ItemsSource = OrdersService.GetOrdersInfo();
            comboOrder.ItemsSource = StatusService.GetStatusInfo();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Classes.Frame.FrameOBJ.GoBack();
        }
    }
}

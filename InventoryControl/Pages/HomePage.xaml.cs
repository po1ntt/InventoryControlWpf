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
using System.Collections.ObjectModel;


namespace InventoryControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
          
            WareHouseEquipDG.ItemsSource = Service.WarehouseEquipService.GetWareHouseEquipment();
        }

        private void PropertiesClick(object sender, RoutedEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new PropertiesPage());
        }

        private void NameFilter(object sender, TextChangedEventArgs e)
        {
            string name = ((TextBox)sender).Text;
            if(name != null)
            {
                WareHouseEquipDG.ItemsSource = null;
                WareHouseEquipDG.ItemsSource = WarehouseEquipService.GetWareHouseEquipmentNameFilter(name);
            }
            else
            {
                WareHouseEquipDG.ItemsSource = null;
                WareHouseEquipDG.ItemsSource = Service.WarehouseEquipService.GetWareHouseEquipment();

            }
        }
    }
}

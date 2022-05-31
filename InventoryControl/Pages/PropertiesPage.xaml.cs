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
using InventoryControl.BdWork;
using InventoryControl.Service;

namespace InventoryControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для PropertiesPage.xaml
    /// </summary>
    public partial class PropertiesPage : Page
    {
        public PropertiesPage()
        {
            InitializeComponent();
            DgBrand.ItemsSource = BrandService.GetBrandInfo();
            DgDepartament.ItemsSource = DepartamentService.GetDepartamentInfo();
            DgEquipment.ItemsSource = EquipmentService.GetEquipmentInfo();
            DgSellers.ItemsSource = SellerService.GetSellerInfo();
            DgType.ItemsSource = TypeEquipmentService.GetTypeOfEquipmentInfo();
        }

        private void BackToMainClick(object sender, RoutedEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new HomePage());
        }
    }
}

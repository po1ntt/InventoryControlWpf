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
    /// Логика взаимодействия для EditBrand.xaml
    /// </summary>
    public partial class EditBrand : Window
    {
        public static Brand brand1;
        public EditBrand(Brand brand)
        {
            InitializeComponent();
            txbBrand.Text = brand.namebrand;
            brand1 = brand;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = BrandService.EditBrand(brand1, txbBrand.Text);
            MessageBox.Show(result);
        }
    }
}

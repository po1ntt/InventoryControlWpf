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
    /// Логика взаимодействия для EditSeller.xaml
    /// </summary>
    public partial class EditSeller : Window
    {
        public Seller seller1;
        public EditSeller(Seller seller)
        {
            InitializeComponent();
            txbSeller.Text = seller.nameSeller;
            seller1 = seller;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = SellerService.EditSeller(seller1, txbSeller.Text);
            MessageBox.Show(result);
        }
    }
}

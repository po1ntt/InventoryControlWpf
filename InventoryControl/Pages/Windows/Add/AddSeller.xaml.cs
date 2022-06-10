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
    /// Логика взаимодействия для AddSeller.xaml
    /// </summary>
    public partial class AddSeller : Window
    {
        public AddSeller()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = Service.SellerService.AddSeller(namepost.Text);
            MessageBox.Show(result);
        }
    }
}

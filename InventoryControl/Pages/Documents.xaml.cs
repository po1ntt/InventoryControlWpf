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

namespace InventoryControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для Documents.xaml
    /// </summary>
    public partial class Documents : Page
    {
        public Documents()
        {
            InitializeComponent();
            Nakladnay_data.ItemsSource = Service.NakladnayService.GetNakladnayInfo();
            Priemka_data.ItemsSource = Service.PriemkaService.GetPriemkaInfo();
            ShetFactura_data.ItemsSource = Service.ShetFacturaService.GetShetFacturaInfo();
        }

        private void Nakladnay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShetFactura_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Priemka_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nakladnay_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
         
            
                ClearAll();
                Nakladay_text.Foreground = Brushes.White;
                nakladnay.BorderBrush = Brushes.Purple;
                nakladnay.Background = Brushes.Purple;
                Nakladnay_data.Visibility = Visibility.Visible;
            
        }
        public void ClearAll()
        {
            Nakladay_text.Foreground = Brushes.Black;
            nakladnay.BorderBrush = Brushes.Blue;
            nakladnay.Background = Brushes.White;
            Nakladnay_data.Visibility = Visibility.Collapsed;
            chet_factura.BorderBrush = Brushes.Blue;
            chet_factura.Background = Brushes.White;
            chet_factura_text.Foreground = Brushes.Black;
            ShetFactura_data.Visibility = Visibility.Collapsed;
            priemka.BorderBrush = Brushes.Blue;
            priemka.Background = Brushes.White;
            priemka_text.Foreground = Brushes.Black;
            Priemka_data.Visibility = Visibility.Collapsed;
        }
        private void priemka_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            ClearAll();
            priemka_text.Foreground = Brushes.White;
            priemka.BorderBrush = Brushes.Purple;
            priemka.Background = Brushes.Purple;
            Priemka_data.Visibility = Visibility.Visible;

        }

        private void chet_factura_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearAll();
            chet_factura_text.Foreground = Brushes.White;
            chet_factura.BorderBrush = Brushes.Purple;
            chet_factura.Background = Brushes.Purple;
            ShetFactura_data.Visibility = Visibility.Visible;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Classes.Frame.FrameOBJ.GoBack();
        }
    }
}

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
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using InventoryControl.Classes;
using InventoryControl.Pages.Windows.Add;

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
        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

            saveFileDialog1.Filter = "EXCEL Files (*.xlsx)|*.xlsx|EXCEL Files 2003 (*.xls)|*.xls|All files (*.*)|*.*";

            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    var path = saveFileDialog1.FileName;
                    myStream.Close();
                    WareHouseEquipDG.SelectAllCells();
                    WareHouseEquipDG.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, WareHouseEquipDG);
                    String resultat = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
                    String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.Text);
                    WareHouseEquipDG.UnselectAllCells();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(path, true, System.Text.Encoding.GetEncoding(1251));
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();

                }
            }



            System.Windows.MessageBox.Show("Файл успешно создан!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new NewOrder());
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WareHouseEquipDG.ItemsSource = null;
            WareHouseEquipDG.ItemsSource = Service.OrdersService.GetOrdersInfo();

        }
    }
}

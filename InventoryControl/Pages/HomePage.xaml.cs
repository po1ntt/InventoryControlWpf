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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Page = Microsoft.Office.Interop.Excel.Page;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using InventoryControl.Classes;
using InventoryControl.Pages.Windows.Add;
using MessageBox = System.Windows.MessageBox;

namespace InventoryControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
       

        public HomePage()
        {
            DataContext = new UserService();
            InitializeComponent();
            bradncombo.ItemsSource = BrandService.GetBrandInfo();
            typeofequip.ItemsSource = TypeEquipmentService.GetTypeOfEquipmentInfo();
            WareHouseEquipDG.ItemsSource = Service.WarehouseEquipService.GetWareHouseEquipment();
            
        }

        private void PropertiesClick(object sender, RoutedEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new PropertiesPage());
        }
        public static Brand brand;
        public static TypeOfEquipment type;
        public static string count;
        public static string NName;

        private void NameFilter(object sender, TextChangedEventArgs e)
        {

            string name = ((System.Windows.Controls.TextBox)sender).Text;
            NName = name;
            if (name != null)
            {
                WareHouseEquipDG.ItemsSource = null;

                WareHouseEquipDG.ItemsSource = Classes.Filters.FiltersWareHouse(name, brand, type, count);
            }

        }

        private void OrdersClick(object sender, RoutedEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new OrdersPage());
        }
        private void DepartamentClick(object sender, RoutedEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new DepartamentPage());
        }

        public HeaderFooter LeftHeader => throw new NotImplementedException();

        public HeaderFooter CenterHeader => throw new NotImplementedException();

        public HeaderFooter RightHeader => throw new NotImplementedException();

        public HeaderFooter LeftFooter => throw new NotImplementedException();

        public HeaderFooter CenterFooter => throw new NotImplementedException();

        public HeaderFooter RightFooter => throw new NotImplementedException();

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
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            WareHouseEquipDG.ItemsSource = null;
            WareHouseEquipDG.ItemsSource = Service.WarehouseEquipService.GetWareHouseEquipment();

        }

        private void WarehouseAdd_Click(object sender, RoutedEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new AddToWareHouseEquip());

        }

        private void AddDepartamentEquipment(object sender, RoutedEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new AddToDepartamentEquipment(WareHouseEquipDG.SelectedItem as WarehouseEquipment));
        }

        private void bradncombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            brand = bradncombo.SelectedItem as Brand;

            WareHouseEquipDG.ItemsSource = null;
            WareHouseEquipDG.ItemsSource = Classes.Filters.FiltersWareHouse(NName, brand, type, count);

        }

        private void typeofequip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type = typeofequip.SelectedItem as TypeOfEquipment;
            WareHouseEquipDG.ItemsSource = null;

            WareHouseEquipDG.ItemsSource = Classes.Filters.FiltersWareHouse(NName, brand, type, count);
        }
        private void DelFilters_Click(object sender, RoutedEventArgs e)
        {
            bradncombo.SelectedIndex = -1;
            typeofequip.SelectedIndex = -1;
            namefilter.Text = null;
            countfilter.Text = null;
            WareHouseEquipDG.ItemsSource = null;
            WareHouseEquipDG.ItemsSource = Service.WarehouseEquipService.GetWareHouseEquipment();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(UserService.userToSave.Role == "Admin")
            {
                Classes.Frame.FrameOBJ.Navigate(new LoggerPage());
            }
            else
            {
                MessageBox.Show("Доступ к логам есть только у администратора");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Service.UserService.userToSave = null;
            Classes.Frame.FrameOBJ.Navigate(new AuthorizePage());
        }
    }
}


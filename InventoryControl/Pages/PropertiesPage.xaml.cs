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
using InventoryControl.Classes;
using InventoryControl.Pages.Windows.Add;
using InventoryControl.Pages.Windows.Edit;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

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
            DgBrand.Items.Clear();
            DgDepartament.Items.Clear();
            DgEquipment.Items.Clear();
            DgSellers.Items.Clear();
            DgType.Items.Clear();
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

        private void Edit_Brand_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Edit_Equipment_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Edit_Type_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Edit_Departament_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Edit_Seller_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBrand_Click(object sender, RoutedEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new AddBrand());
        }

        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new AddTypeEquipment());
        }
        private void AddEquipment_Click(object sender, RoutedEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new AddEquipment());
        }
        private void AddDepartament_Click(object sender, RoutedEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new AddDepartament());
        }
        private void AddSeller_Click(object sender, RoutedEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new AddSeller());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DgBrand.ItemsSource = null;
            DgDepartament.ItemsSource = null;
            DgEquipment.ItemsSource = null;
            DgSellers.ItemsSource = null;
            DgType.ItemsSource = null;
            DgBrand.ItemsSource = BrandService.GetBrandInfo();
            DgDepartament.ItemsSource = DepartamentService.GetDepartamentInfo();
            DgEquipment.ItemsSource = EquipmentService.GetEquipmentInfo();
            DgSellers.ItemsSource = SellerService.GetSellerInfo();
            DgType.ItemsSource = TypeEquipmentService.GetTypeOfEquipmentInfo();

        }
        private void Excel_ClickBrand(object sender, RoutedEventArgs e)
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
                    DgBrand.SelectAllCells();
                    DgBrand.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, DgBrand);
                    String resultat = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
                    String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.Text);
                    DgBrand.UnselectAllCells();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(path, true, System.Text.Encoding.GetEncoding(1251));
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();

                }
            }



            System.Windows.MessageBox.Show("Файл успешно создан!");
        }
        private void Excel_ClickType(object sender, RoutedEventArgs e)
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
                    DgType.SelectAllCells();
                    DgType.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, DgBrand);
                    String resultat = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
                    String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.Text);
                    DgType.UnselectAllCells();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(path, true, System.Text.Encoding.GetEncoding(1251));
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();

                }
            }



            System.Windows.MessageBox.Show("Файл успешно создан!");
        }
        private void Excel_ClickDepartament(object sender, RoutedEventArgs e)
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
                    DgDepartament.SelectAllCells();
                    DgDepartament.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, DgBrand);
                    String resultat = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
                    String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.Text);
                    DgDepartament.UnselectAllCells();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(path, true, System.Text.Encoding.GetEncoding(1251));
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();

                }
            }



            System.Windows.MessageBox.Show("Файл успешно создан!");
        }
        private void Excel_ClickSeller(object sender, RoutedEventArgs e)
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
                    DgSellers.SelectAllCells();
                    DgSellers.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, DgBrand);
                    String resultat = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
                    String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.Text);
                    DgSellers.UnselectAllCells();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(path, true, System.Text.Encoding.GetEncoding(1251));
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();

                }
            }



            System.Windows.MessageBox.Show("Файл успешно создан!");
        }
        private void Excel_ClickEquipment(object sender, RoutedEventArgs e)
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
                    DgEquipment.SelectAllCells();
                    DgEquipment.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, DgBrand);
                    String resultat = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
                    String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.Text);
                    DgEquipment.UnselectAllCells();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(path, true, System.Text.Encoding.GetEncoding(1251));
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();

                }
            }



            System.Windows.MessageBox.Show("Файл успешно создан!");
        }
       
    }
}

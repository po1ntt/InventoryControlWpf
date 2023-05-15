using InventoryControl.BdWork;
using InventoryControl.Classes;
using InventoryControl.Control;
using InventoryControl.Pages.Windows.Add;
using InventoryControl.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecorsOfСoming.xaml
    /// </summary>
    public partial class RecorsOfСoming : Page
    {
        public string TitlePage { get; set;}
        public RecorsOfСoming()
        {
            InitializeComponent();
            DataContext = this;
            TitlePage = "Записи о приходе";
            InventoryСontrolEntities1 inventoryСontrolEntities1 = new InventoryСontrolEntities1();
            bradncombo.ItemsSource = BrandService.GetBrandInfo();
            typeofequip.ItemsSource = TypeEquipmentService.GetTypeOfEquipmentInfo();
            empCombo.ItemsSource = inventoryСontrolEntities1.Employers.ToList();
            RecordsComingDG.ItemsSource = Classes.Filters.FilterRecordsComing(brand,employe,type,NName,selectedDate);

        }
        public ObservableCollection<ComingRecords> recorsOfСomings = new ObservableCollection<ComingRecords>();
        public static Brand brand;
        public static Employers employe;
        public static string selectedDate;

        public static TypeOfEquipment type;
        public static string NName;
        private void bradncombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            brand = bradncombo.SelectedItem as Brand;

            RecordsComingDG.ItemsSource = null;
            RecordsComingDG.ItemsSource = Classes.Filters.FilterRecordsComing(brand, employe, type, NName, selectedDate);

        }

        private void typeofequip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type = typeofequip.SelectedItem as TypeOfEquipment;
            RecordsComingDG.ItemsSource = null;
            RecordsComingDG.ItemsSource = Classes.Filters.FilterRecordsComing(brand, employe, type, NName, selectedDate);
        }
        private void DelFilters_Click(object sender, RoutedEventArgs e)
        {
            bradncombo.SelectedIndex = -1;
            typeofequip.SelectedIndex = -1;
            empCombo.SelectedIndex = -1;
            dpDate.SelectedDate = null;
            namefilter.Text = null;
            RecordsComingDG.ItemsSource = null;
            RecordsComingDG.ItemsSource = Classes.Filters.FilterRecordsComing(brand, employe, type, NName, selectedDate);

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {


            RecordsComingDG.ItemsSource = null;
            RecordsComingDG.ItemsSource = Classes.Filters.FilterRecordsComing(brand, employe, type, NName, selectedDate);
  
        }
        private void NameFilter(object sender, TextChangedEventArgs e)
        {

            string name = ((System.Windows.Controls.TextBox)sender).Text;
            NName = name;
            if (name != null)
            {
                RecordsComingDG.ItemsSource = null;
                RecordsComingDG.ItemsSource = Classes.Filters.FilterRecordsComing(brand, employe, type, NName, selectedDate);
            }

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
                    RecordsComingDG.SelectAllCells();
                    RecordsComingDG.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, RecordsComingDG);
                    String resultat = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
                    String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.Text);
                    RecordsComingDG.UnselectAllCells();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(path, true, System.Text.Encoding.GetEncoding(1251));
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();

                }
            }



            System.Windows.MessageBox.Show("Файл успешно создан!");
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datapicker = sender as DatePicker;
            if (string.IsNullOrWhiteSpace(datapicker.Text))
            {
                selectedDate = "";
                RecordsComingDG.ItemsSource = null;
                RecordsComingDG.ItemsSource = Classes.Filters.FilterRecordsComing(brand, employe, type, NName, selectedDate);
            }
            else
            {
                selectedDate = Convert.ToDateTime(datapicker.Text).ToString("d");
                if (selectedDate != null)
                {
                    RecordsComingDG.ItemsSource = null;
                    RecordsComingDG.ItemsSource = Classes.Filters.FilterRecordsComing(brand, employe, type, NName, selectedDate);
                }
            }
            
        }

        private void empCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            employe = empCombo.SelectedItem as Employers;

            RecordsComingDG.ItemsSource = null;
            RecordsComingDG.ItemsSource = Classes.Filters.FilterRecordsComing(brand, employe, type, NName, selectedDate);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var filepath = System.IO.Directory.GetCurrentDirectory();

            var file = new WordService(@".\WordTemplate\TemplateDocladnay.docx");
            bool result = file.Process(RecordsComingDG.SelectedItem as ComingRecords);
            if (result == true)
            {
                System.Windows.MessageBox.Show("Документ создан");
            }
            else
            {
                System.Windows.MessageBox.Show(":L");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new AddRecordComing());
        }
    }
}

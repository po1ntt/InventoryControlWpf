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
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using InventoryControl.Service;
using InventoryControl.Classes;
using InventoryControl.Pages.Windows.Add;

namespace InventoryControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для DepartamentPage.xaml
    /// </summary>
    public partial class DepartamentPage : Page
    {
        public string TitlePage { get; set; }
        public DepartamentPage()
        {
            InitializeComponent();
            DataContext = this;
            TitlePage = "Департаменты";
            DepCombo.ItemsSource = Service.DepartamentService.GetDepartamentInfo();
            DepCombo.SelectedIndex = 0;
            var departament = DepCombo.SelectedItem as Departament;
            DepartamentEquipDG.ItemsSource = Service.EquipmentDepartamentService.GetEquipmentDepartamentInfo(departament.name_departament);
        }

      

        private void DepCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var departament = DepCombo.SelectedItem as Departament;
            DepartamentEquipDG.ItemsSource = null;
            DepartamentEquipDG.ItemsSource = Service.EquipmentDepartamentService.GetEquipmentDepartamentInfo(departament.name_departament);
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
                    DepartamentEquipDG.SelectAllCells();
                    DepartamentEquipDG.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, DepartamentEquipDG);
                    String resultat = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
                    String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.Text);
                    DepartamentEquipDG.UnselectAllCells();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(path, true, System.Text.Encoding.GetEncoding(1251));
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();

                }
            }



            System.Windows.MessageBox.Show("Файл успешно создан!");
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           
            var departament = DepCombo.SelectedItem as Departament;
            if (departament != null)
            {
                DepartamentEquipDG.ItemsSource = null;
                DepartamentEquipDG.ItemsSource = Service.EquipmentDepartamentService.GetEquipmentDepartamentInfo(departament.name_departament);
            }
          

        }

        private void AddToDep_Click(object sender, RoutedEventArgs e)
        {
            var departament = DepCombo.SelectedItem as Departament;

            System.Windows.MessageBox.Show(departament.name_departament);
           Base.OpenCenterPosAndOpen(new AddToDepFromDep(DepCombo.SelectedItem as Departament));
            
        }
    }
}

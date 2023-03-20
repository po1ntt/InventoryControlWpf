using InventoryControl.Control;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для LoggerPage.xaml
    /// </summary>
    public partial class LoggerPage : Page
    {
        public string TitlePage { get; set; }
        public LoggerPage()
        {
            InitializeComponent();
            DataContext = this;
            TitlePage = "Логи";
            dgdata.ItemsSource = Service.LoggerService.GetLogInfo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                    dgdata.SelectAllCells();
                    dgdata.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, dgdata);
                    String resultat = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
                    String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.Text);
                   dgdata.UnselectAllCells();
                    System.IO.StreamWriter file1 = new System.IO.StreamWriter(path, true, System.Text.Encoding.GetEncoding(1251));
                    file1.WriteLine(result.Replace(',', ' '));
                    file1.Close();

                }
            }



            System.Windows.MessageBox.Show("Файл успешно создан!");
        }

      
    }
}

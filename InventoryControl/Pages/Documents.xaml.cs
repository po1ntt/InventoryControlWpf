using System;
using System.Collections.Generic;
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
using InventoryControl.BdWork;
using Spire.Doc;

namespace InventoryControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для Documents.xaml
    /// </summary>
    public partial class Documents : Page
    {
        public string TitlePage { get; set; } = "Документы";
        public Documents()
        {
            InitializeComponent();
            DataContext= this;
            DGDATA.ItemsSource = Service.updservice.GetUPDInfo();
        }
        public void ToWordSomeDocument()
        {

        }

        private void Docs_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = ((System.Windows.Controls.Button)sender);
            if (button.Name == "Poluchka") 
            {
              
            }
            else
            {

            }

            
        }

        private void PackIcon_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new UPDView(DGDATA.SelectedItem as Universalniy_Dogovor_peredachi));
        }

      

        private void DGDATA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new UPDView(DGDATA.SelectedItem as Universalniy_Dogovor_peredachi));

        }
    }
}

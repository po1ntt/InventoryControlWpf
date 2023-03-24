using InventoryControl.BdWork;
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
    /// Логика взаимодействия для UPDView.xaml
    /// </summary>
    public partial class UPDView : Page
    {
       public Universalniy_Dogovor_peredachi UPD { get; set; }
        public UPDView(Universalniy_Dogovor_peredachi universalniy_Dogovor_Peredachi)
        {

            InitializeComponent();
            UPD = universalniy_Dogovor_Peredachi;
            DataContext = UPD;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Classes.Frame.FrameOBJ.GoBack();
        }
    }
}

using InventoryControl.BdWork;
using InventoryControl.Service;
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

namespace InventoryControl.Pages.Windows.Edit
{
    /// <summary>
    /// Логика взаимодействия для EditDepartament.xaml
    /// </summary>
    public partial class EditDepartament : Window
    {
        public Departament departament1;
        public EditDepartament(Departament departament)
        {
            InitializeComponent();
            departament1 = departament;
            txbDepartament.Text = departament1.name_departament;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string result = DepartamentService.EditDepartament(departament1, txbDepartament.Text);
            MessageBox.Show(result);
        }
    }
}

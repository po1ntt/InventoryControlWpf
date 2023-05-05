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

namespace InventoryControl.Pages.Windows.Add
{
    /// <summary>
    /// Логика взаимодействия для AddRecordComing.xaml
    /// </summary>
    public partial class AddRecordComing : Window
    {
        public AddRecordComing()
        {
            InitializeComponent();
            InventoryСontrolEntities1 inventoryСontrolEntities1 = new InventoryСontrolEntities1();
            cmbEmp.ItemsSource = inventoryСontrolEntities1.Employers.ToList();
            cmbEquip.ItemsSource = EquipmentService.GetEquipmentInfo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InventoryСontrolEntities1  inventoryСontrolEntities1 = new InventoryСontrolEntities1();
            int countEquip = Convert.ToInt32(txbCountEquip.Text);
            Employers employers = cmbEmp.SelectedItem as Employers;
            Equipment equipment = cmbEquip.SelectedItem  as Equipment;
            DateTime datetime = DateTime.Now;
            
            if(countEquip > 0 && employers != null &&  equipment != null)
            {
                inventoryСontrolEntities1.ComingRecords.Add(new ComingRecords()
                {
                    Emp_id = employers.id_employers,
                    Equipment_id = equipment.id_equip,
                    DateChanging = datetime,
                    CountEquip = countEquip,
                    NumberOfNakladnay = Guid.NewGuid().ToString()
                });
                inventoryСontrolEntities1.SaveChanges();
                MessageBox.Show("Новая запись добавлена");
               
            }
            else
            {
                MessageBox.Show("Данные заполнены не корректно");
            }
        }
    }
}

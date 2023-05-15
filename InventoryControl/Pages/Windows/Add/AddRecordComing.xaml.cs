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
            int countEquip = 0;
            if (!string.IsNullOrWhiteSpace(txbCountEquip.Text))
            {
                 countEquip = Convert.ToInt32(txbCountEquip.Text);

            }
            int rashEquip = 0;
            if (!string.IsNullOrWhiteSpace(txbRashod.Text))
            {
                rashEquip = Convert.ToInt32(txbRashod.Text);

            }           
            Employers employers = cmbEmp.SelectedItem as Employers;
            Equipment equipment = cmbEquip.SelectedItem  as Equipment;
            string datetime = DateTime.Today.ToString("d");
           
            if(countEquip > 0 && employers != null &&  equipment != null)
            {
                if (checkIsThatEquipmentAlreadyExists(equipment))
                {
                    var equipmentTest = inventoryСontrolEntities1.ComingRecords.FirstOrDefault(p => p.Equipment_id == equipment.id_equip);
                    equipmentTest.CountEquip = equipmentTest.CountEquip + countEquip;
                    equipmentTest.Rashod = rashEquip + equipmentTest.Rashod;
                    equipmentTest.Ostatok = equipmentTest.CountEquip - equipmentTest.Rashod;
                    if(equipmentTest.Ostatok >= 0)
                    {
                        equipmentTest.DateChanging = datetime;
                        equipmentTest.Emp_id = employers.id_employers;
                        inventoryСontrolEntities1.SaveChanges();
                        MessageBox.Show("Запись обновлена");
                    }
                    else
                    {
                        MessageBox.Show("Расход введен не корректно. Остаток меньше 0");
                    }
                }
                else
                {
                    int ostatok = countEquip - rashEquip;
                    if (ostatok >= 0)
                    {
                        inventoryСontrolEntities1.ComingRecords.Add(new ComingRecords()
                        {
                            Emp_id = employers.id_employers,
                            Equipment_id = equipment.id_equip,
                            DateChanging = datetime,
                            CountEquip = countEquip,
                            Rashod = rashEquip,
                            Ostatok = countEquip - rashEquip,
                            NumberOfNakladnay = Guid.NewGuid().ToString()
                        });
                        inventoryСontrolEntities1.SaveChanges();
                        MessageBox.Show("Новая запись добавлена");
                    }
                    else
                    {
                        MessageBox.Show("Расход введен не корректно. Остаток меньше 0");
                    }
                   
                }
             
               
            }
            else
            {
                MessageBox.Show("Данные заполнены не корректно");
            }
        }
        private bool checkIsThatEquipmentAlreadyExists(Equipment equipment)
        {
            InventoryСontrolEntities1 inventoryСontrolEntities1 = new InventoryСontrolEntities1();
            var equipmentCheck = inventoryСontrolEntities1.ComingRecords.FirstOrDefault(p=> p.Equipment_id == equipment.id_equip);
            if (equipmentCheck != null)
                return true;
            else
                return false;
        }
    }
}

using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryControl.Service
{
    class EquipmentDepartamentService
    {
        public static ObservableCollection<DepartamentEquipment> GetEquipmentDepartamentInfo(string namedep)
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var Collection = new ObservableCollection<DepartamentEquipment>();
            var items = context.DepartamentEquipment.ToList().Where(p => p.Departament.name_departament == namedep);
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string addDepartamentEquipment(int id_equip, int id_dep, int count)
        {
            string result = "Ошибка";
            
            using(InventoryСontrolEntities1 context = new InventoryСontrolEntities1())
            {

                var depEquip = context.DepartamentEquipment.FirstOrDefault(p => p.id_equipdep == id_equip && p.Departament.id_departament == id_dep);
                var warehouseequip = context.WarehouseEquipment.FirstOrDefault(p => p.id_equipment == id_equip);
                int countwarehouse = Convert.ToInt32(warehouseequip.count);
                if(count > countwarehouse)
                {
                    MessageBox.Show("Введенное кол-во больше чем есть на складе");
                }
                else
                {
                    if (depEquip == null)
                    {
                        context.DepartamentEquipment.Add(new DepartamentEquipment
                        {
                            id_depEquip = context.DepartamentEquipment.Count() + 1,
                            id_dep = id_dep,
                            id_equipdep = id_equip,
                            count = count
                        });
                        result = "Запись успешно добавлена";
                        Service.LoggerService.AddLog("Добавление оборудование в отдел", UserService.userToSave.Login, DateTime.Now, "Оборудование отдела", warehouseequip.Equipment.name);

                        warehouseequip.count = Convert.ToString(Convert.ToInt32(warehouseequip.count) - count);
                        context.SaveChanges();
                    }
                    else
                    {
                        if (count != 0)
                        {
                            var depEquipment = context.DepartamentEquipment.Where(p => p.id_equipdep == id_equip).FirstOrDefault();
                            depEquipment.count = depEquipment.count + count;
                            warehouseequip.count = Convert.ToString(Convert.ToInt32(warehouseequip.count) - count);
                            Service.LoggerService.AddLog("Добавление оборудование в отдел", UserService.userToSave.Login, DateTime.Now, "Оборудование отдела", depEquip.Equipment.name);

                            context.SaveChanges();
                            result = "Обновлено количество техники";
                        }
                        else
                        {
                            result = "Запись уже существует и количество новой техники равно 0, ничего не изменилось";
                        }

                    }
                }
               
            }
            return result;
        }
    }
}

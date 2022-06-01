using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    class EquipmentDepartamentService
    {
        public static ObservableCollection<DepartamentEquipment> GetEquipmentDepartamentInfo()
        {
            InventoryСontrolEntities context = new InventoryСontrolEntities();
            var Collection = new ObservableCollection<DepartamentEquipment>();
            var items = context.DepartamentEquipment.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string addDepartamentEquipment(int id_equip, int id_dep, int count)
        {
            string result = "Ошибка";
            using(InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var depEquip = context.DepartamentEquipment.FirstOrDefault(p => p.id_equipdep == id_equip);
               
                if (depEquip != null)
                {
                    context.DepartamentEquipment.Add(new DepartamentEquipment
                    {
                        id_depEquip = context.DepartamentEquipment.Count() + 1,
                        id_dep = id_dep,
                        id_equipdep = id_equip,
                        count = count
                    });
                    result = "Запись успешно добавлена";
                }
                else
                {
                    if (count != 0)
                    {
                        var depEquipment = context.DepartamentEquipment.Where(p => p.id_equipdep == id_equip).FirstOrDefault();
                        depEquipment.count = depEquipment.count + count;
                        context.SaveChanges();
                        result = "Обновлено количество техники";
                    }
                    else
                    {
                        result = "Запись уже существует и количество новой техники равно 0, ничего не изменилось";
                    }

                }
            }
            return result;
        }
    }
}

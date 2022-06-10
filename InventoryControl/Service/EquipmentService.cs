using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    class EquipmentService
    {
        public static ObservableCollection<Equipment> GetEquipmentInfo()
        {
            InventoryСontrolEntities context = new InventoryСontrolEntities();
            var Collection = new ObservableCollection<Equipment>();
            var items = context.Equipment.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string addEquipment(string nameequip, int id_typeequip, int brand)
        {
            string result = "Ошибка";
            using(InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var equip = context.Equipment.FirstOrDefault(p => p.name == nameequip);
                if(equip == null)
                {
                    context.Equipment.Add(new Equipment
                    {
                        id_equip = context.Equipment.Count() + 1,
                        name = nameequip,
                        id_brand = brand,
                        typeofequipment_id = id_typeequip
                        
                       
                    });
                    result = "Новая техника успешно добавлена";
                    context.SaveChanges();
                }
                else
                {
                    result = "Техника уже существует";
                }
            }
            return result;
        }
    }
}

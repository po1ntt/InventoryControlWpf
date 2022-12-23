using InventoryControl.BdWork;
using InventoryControl.Pages.Windows.Add;
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
                    Service.LoggerService.AddLog("Добавление", UserService.userToSave.Login, DateTime.Now, "Техника", nameequip);

                    context.SaveChanges();
                }
                else
                {
                    result = "Техника уже существует";
                }
            }
            return result;
        }
        public static string EditEquipment(Equipment oldequipment, Brand brand, TypeOfEquipment type, string name)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var departament = context.Equipment.FirstOrDefault(p => p.id_equip == oldequipment.id_equip);
                if (departament != null)
                {
                    departament.name = name;
                    departament.id_brand = brand.id_brand;
                    departament.typeofequipment_id = type.id_typeEquip;
                    Service.LoggerService.AddLog("Редактирование", UserService.userToSave.Login, DateTime.Now, "Техника", oldequipment.name);

                    context.SaveChanges();
                    result = "Техника успешно изменена";
                }
                else
                {
                    result = "Передан null;(";
                }
            }
            return result;
        }
        public static string DeleteEquipment(Equipment type)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var brandtodelete = context.Equipment.FirstOrDefault(p => p.typeofequipment_id == type.id_equip);
                if (brandtodelete != null)
                {
                    context.Equipment.Remove(brandtodelete);
                    Service.LoggerService.AddLog("Удаление", UserService.userToSave.Login, DateTime.Now, "Техника", type.name);

                    context.SaveChanges();
                    result = "Техника с названием " + type.name + " успешно удален";
                }
                else
                {
                    result = "Господи опять null";
                }
            }
            return result;
        }
    }
}

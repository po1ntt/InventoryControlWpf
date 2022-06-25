using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    class TypeEquipmentService
    {
        public static ObservableCollection<TypeOfEquipment> GetTypeOfEquipmentInfo()
        {
            InventoryСontrolEntities context = new InventoryСontrolEntities();
            var Collection = new ObservableCollection<TypeOfEquipment>();
            var items = context.TypeOfEquipment.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string AddTypeEquipment(string typeEquip)
        {
            string result = "Ошибка";

            using (InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var type = context.TypeOfEquipment.FirstOrDefault(p => p.NameTypeEquip == typeEquip);
                if (type!=null)
                {

                    result = "тип техники уже существует";
                }
                else
                {
                    context.TypeOfEquipment.Add(new TypeOfEquipment
                    {
                        id_typeEquip = context.TypeOfEquipment.Count() + 1,
                        NameTypeEquip = typeEquip

                    });
                    result = "Новый тип техники успешно добавлен";
                    context.SaveChanges();
                }
            }
            return result;
        }
        public static string EditTypeOf(TypeOfEquipment typeOfEquipment, string nametype)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var departament = context.TypeOfEquipment.FirstOrDefault(p => p.id_typeEquip == typeOfEquipment.id_typeEquip);
                if (departament != null)
                {
                    departament.NameTypeEquip = nametype;
                    context.SaveChanges();
                    result = "Тип техники успешно изменен";
                }
                else
                {
                    result = "Передан null;(";
                }
            }
            return result;
        }
        public static string DeleteType(TypeOfEquipment type)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var brandtodelete = context.TypeOfEquipment.FirstOrDefault(p => p.id_typeEquip == type.id_typeEquip);
                if (brandtodelete != null)
                {
                    context.TypeOfEquipment.Remove(brandtodelete);
                    context.SaveChanges();
                    result = "Тип техники с названием " + type.NameTypeEquip + " успешно удален";
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

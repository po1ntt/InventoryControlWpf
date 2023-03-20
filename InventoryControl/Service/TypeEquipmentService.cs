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
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
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

            using (InventoryСontrolEntities1 context = new InventoryСontrolEntities1())
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
                    Service.LoggerService.AddLog("Добавление", "Тип техники", typeEquip);

                    result = "Новый тип техники успешно добавлен";
                    context.SaveChanges();
                }
            }
            return result;
        }
        public static string EditTypeOf(TypeOfEquipment typeOfEquipment, string nametype)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities1 context = new InventoryСontrolEntities1())
            {
                var departament = context.TypeOfEquipment.FirstOrDefault(p => p.id_typeEquip == typeOfEquipment.id_typeEquip);
                if (departament != null)
                {
                    departament.NameTypeEquip = nametype;
                    Service.LoggerService.AddLog("Редактирование", "Тип техники", typeOfEquipment.NameTypeEquip);

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
            using (InventoryСontrolEntities1 context = new InventoryСontrolEntities1())
            {
                var brandtodelete = context.TypeOfEquipment.FirstOrDefault(p => p.id_typeEquip == type.id_typeEquip);
                if (brandtodelete != null)
                {
                    context.TypeOfEquipment.Remove(brandtodelete);
                    Service.LoggerService.AddLog("Удаление", "Тип техники", type.NameTypeEquip);

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

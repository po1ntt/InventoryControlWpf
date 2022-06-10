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
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControl.BdWork;

namespace InventoryControl.Service
{
    class WarehouseEquipService
    {
        public static ObservableCollection<WarehouseEquipment> GetWareHouseEquipment()
        {
            InventoryСontrolEntities context = new InventoryСontrolEntities();
            var Collection = new ObservableCollection<WarehouseEquipment>();
            var items = context.WarehouseEquipment.ToList();
            foreach(var item in items)
            {
                if(item.count == "0")
                {
                    item.count.ToString();
                    item.count = "Нет в наличии";
                }
                Collection.Add(item);
            }
            return Collection;
        }
        public static ObservableCollection<WarehouseEquipment> GetWareHouseEquipmentNameFilter(string name)
        {
            InventoryСontrolEntities context = new InventoryСontrolEntities();
            var Collection = new ObservableCollection<WarehouseEquipment>();
            var items = context.WarehouseEquipment.ToList().Where(p => p.Equipment.name.Contains(name));
            foreach (var item in items)
            {
                if (item.count == "0")
                {
                    item.count.ToString();
                    item.count = "Нет в наличии";
                }
                Collection.Add(item);
            }
            return Collection;
        }
        public static string AddNewEquipmentToWarehouse(int id_equip, int count)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                bool isExist = false;
                var warehouseEquip = context.WarehouseEquipment.ToList();
                foreach(var equip in warehouseEquip)
                {
                    if(equip.id_equipment == id_equip)
                    {
                        isExist = true;
                 
                    }
                    
                }
                if(isExist == false)
                {
                    context.WarehouseEquipment.Add(new WarehouseEquipment
                    {
                        id_warehouseequipment = context.WarehouseEquipment.Count() + 1,
                        id_equipment = id_equip,
                        count = count.ToString()
                    });
                    result = "Запись успешно добавлена";
                }
                else
                {
                    if(count != 0)
                    {
                        var equipmentWareHouse = context.WarehouseEquipment.Where(p => p.id_equipment == id_equip).FirstOrDefault();
                        equipmentWareHouse.count = Convert.ToString(Convert.ToInt32(equipmentWareHouse.count) + count);
                        result = "Обновлено количество";
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

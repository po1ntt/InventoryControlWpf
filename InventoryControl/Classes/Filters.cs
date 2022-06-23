using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Classes
{
    class Filters
    {
        public static ObservableCollection<WarehouseEquipment> FiltersWareHouse(string name, Brand brand, TypeOfEquipment type, string count)
        {
            InventoryСontrolEntities context = new InventoryСontrolEntities();
            var Collection = new ObservableCollection<WarehouseEquipment>();
            var items = new List<WarehouseEquipment>();
            if (name != null || brand != null || type != null || count != null)
            {
                if (name == null && brand != null && type != null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.count == count && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if(brand == null && name != null && type != null && count != null){
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.count == count && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip ).ToList();

                }
                else if(brand != null && name != null && type == null && count != null)
                {

                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.count == count && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if(brand != null && name != null && type != null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (name == null && brand == null && type != null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.count == count && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                // name
                else if (name != null && brand != null && type == null && count == null)
                {

                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (name != null && brand == null && type == null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.count == count).ToList();

                }
               
                else if (name != null && brand == null && type != null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                // gdfgdf
                // brand
                else if (name == null && brand != null && type == null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.Brand.namebrand == brand.namebrand && p.count == count).ToList();

                }

                else if (name == null && brand != null && type != null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.Brand.namebrand == brand.namebrand && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
               // type

                else if (name != null && brand == null && type == null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.count == count).ToList();

                }
                // по одному
                else if (name != null && brand == null && type == null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name)).ToList();

                }
                else if (name == null && brand != null && type == null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (name == null && brand == null && type != null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                else if (name == null && brand == null && type == null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.count == count).ToList();

                }

            }
           
            if(items != null)
            {
                foreach (var item in items)
                {

                    Collection.Add(item);
                }
                
            }
                    
            return Collection;
        }
    }
}

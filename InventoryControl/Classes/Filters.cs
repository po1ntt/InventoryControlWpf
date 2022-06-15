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
                if(name == null)
                {

                }
                else if(brand == null){

                }
                else if(type == null){


                }
                else if(count != null){

                }
                items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.count == count && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

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

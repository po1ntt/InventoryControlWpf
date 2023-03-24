using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    public class updservice
    {
        public static ObservableCollection<Universalniy_Dogovor_peredachi> GetUPDInfo()
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var Collection = new ObservableCollection<Universalniy_Dogovor_peredachi>();
            var items = context.Universalniy_Dogovor_peredachi.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
    }
}

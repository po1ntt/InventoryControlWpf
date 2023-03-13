using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    public class PriemkaService
    {
        public static ObservableCollection<ActPriemka> GetPriemkaInfo()
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var Collection = new ObservableCollection<ActPriemka>();
            var items = context.ActPriemka.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
    }
}

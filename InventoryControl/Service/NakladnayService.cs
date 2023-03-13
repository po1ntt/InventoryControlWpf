using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    public class NakladnayService
    {
        public static ObservableCollection<Nakladnay> GetNakladnayInfo()
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var Collection = new ObservableCollection<Nakladnay>();
            var items = context.Nakladnay.ToList();
            foreach (var item in items)
            {
               
                Collection.Add(item);
            }
            return Collection;
        }
    }
}

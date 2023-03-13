using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    public class ShetFacturaService
    {
        public static ObservableCollection<ShetFactura> GetShetFacturaInfo()
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var Collection = new ObservableCollection<ShetFactura>();
            var items = context.ShetFactura.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
    }
}

using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    class OrdersService
    {
        public static ObservableCollection<Orders> GetOrdersInfo()
        {
            InventoryСontrolEntities context = new InventoryСontrolEntities();
            var Collection = new ObservableCollection<Orders>();
            var items = context.Orders.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string addOrder(int count, int id_equip, int seller_id, int price)
        {
            string result = "Ошибка";
            using(InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                context.Orders.Add(new Orders
                {
                    id_orders = context.Orders.Count() + 1,
                    id_status = 1,
                    Equipment_id = id_equip,
                    seller_id = seller_id,
                    priceForOne = price,
                    Count = count
                    
                });
                result = "Запись успешно добавлена";
            }
            return result;
        }
    }
}

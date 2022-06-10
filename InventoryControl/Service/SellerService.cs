using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    class SellerService
    {
        public static ObservableCollection<Seller> GetSellerInfo()
        {
            InventoryСontrolEntities context = new InventoryСontrolEntities();
            var Collection = new ObservableCollection<Seller>();
            var items = context.Seller.ToList();
            foreach (var item in items)
            {
       
                Collection.Add(item);
            }
            return Collection;
        }
        public static string AddSeller(string namesellerr)
        {
            string result = "Ошибка";

            using (InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var brand = context.Seller.FirstOrDefault(p => p.nameSeller == namesellerr);
                if (brand != null)
                {

                    result = "Продавец уже существует";
                }
                else
                {
                    context.Seller.Add(new Seller
                    {
                        id_seller = context.Seller.Count() + 1,
                        nameSeller = namesellerr

                    });
                    result = "Новый поставщик успешно добавлен";
                    context.SaveChanges();
                }
            }
            return result;
        }

    }
}

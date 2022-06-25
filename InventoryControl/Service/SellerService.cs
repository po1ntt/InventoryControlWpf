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
        public static string EditSeller(Seller seller1, string seller)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var departament = context.Seller.FirstOrDefault(p => p.id_seller == seller1.id_seller);
                if (departament != null)
                {
                    departament.nameSeller = seller;
                    context.SaveChanges();
                    result = "Продавец успешно изменен";
                }
                else
                {
                    result = "Передан null;(";
                }
            }
            return result;
        }
        public static string DeleteSeller(Seller type)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var brandtodelete = context.Seller.FirstOrDefault(p => p.id_seller == type.id_seller);
                if (brandtodelete != null)
                {
                    context.Seller.Remove(brandtodelete);
                    context.SaveChanges();
                    result = "Техника с названием " + type.nameSeller + " успешно удален";
                }
                else
                {
                    result = "Господи опять null";
                }
            }
            return result;
        }

    }
}

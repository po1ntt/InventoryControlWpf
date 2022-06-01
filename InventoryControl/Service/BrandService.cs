using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    class BrandService
    {
        public static ObservableCollection<Brand> GetBrandInfo()
        {
            InventoryСontrolEntities context = new InventoryСontrolEntities();
            var Collection = new ObservableCollection<Brand>();
            var items = context.Brand.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string AddBrand(string namebrand)
        {
            string result = "Ошибка";
            
            using(InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var brand = context.Brand.FirstOrDefault(p => p.namebrand == namebrand);
                 if(brand.namebrand == namebrand)
                {
                    
                    result = "Бренд уже существует";
                }
                else
                {
                    context.Brand.Add(new Brand
                    {
                        id_brand = context.Brand.Count() + 1,
                        namebrand = namebrand
                        
                    });
                    result = "Новый бренд успешно добавлен";
                }
            }
            return result;
        }
        public static string EditBrand(Brand oldbrand, string namebrand)
        {
            string result = "Ошибка";
            using(InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var brand = context.Brand.FirstOrDefault(p => p.id_brand == oldbrand.id_brand);
                if(brand != null)
                {
                    brand.namebrand = namebrand;
                    context.SaveChanges();
                    result = "Бренд успешно изменен";
                }
                else
                {
                    result = "Господи опять null передал, научись уже понимать с#";
                }
            }
            return result;
        }
        public static string DeleteBrand(Brand brand)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities context = new InventoryСontrolEntities())
            {
                var brandtodelete = context.Brand.FirstOrDefault(p => p.id_brand == brand.id_brand);
                if(brandtodelete != null)
                {
                    context.Brand.Remove(brandtodelete);
                    context.SaveChanges();
                    result = "Бренд с названием " + brand.namebrand + " успешно удален";
                }
                else
                {
                    result = "Господи опять null передал, научись уже понимать с#";
                }
            }
            return result;
        }
    }
}

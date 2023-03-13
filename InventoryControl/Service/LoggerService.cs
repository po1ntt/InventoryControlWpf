using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    internal class LoggerService
    {
        public static ObservableCollection<Logger> GetLogInfo()
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var Collection = new ObservableCollection<Logger>();
            var items = context.Logger.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string AddLog(string Operation, string UserLogin, DateTime date, string changedata, string namedata)
        {
            string result = "Ошибка";

            using (InventoryСontrolEntities1 context = new InventoryСontrolEntities1())
            {
             
                    context.Logger.Add(new Logger
                    {
                        Operation = Operation,
                        UserLogin = UserLogin,
                        ChangeData = changedata,
                        NameData = namedata,
                        TimeChange = date,
                        id_log = context.Logger.Count() + 1


                    });
                    result = "Новый лог успешно добавлен";
                    context.SaveChanges();
                
            }
            return result;
        }
    }
}

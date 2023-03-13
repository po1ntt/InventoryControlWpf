using InventoryControl.BdWork;
using InventoryControl.Pages.Windows.Add;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Service
{
    class DepartamentService
    {
        public static ObservableCollection<Departament> GetDepartamentInfo()
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var Collection = new ObservableCollection<Departament>();
            var items = context.Departament.ToList();
            foreach (var item in items)
            {

                Collection.Add(item);
            }
            return Collection;
        }
        public static string AddDepartament(string namedep)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities1 context = new InventoryСontrolEntities1())
            {
                var departament = context.Departament.FirstOrDefault(p => p.name_departament == namedep);
                if(departament == null)
                {
                    context.Departament.Add(new Departament 
                    { 
                        id_departament = context.Departament.Count() + 1,
                        name_departament = namedep
                        
                    });
                    Service.LoggerService.AddLog("Добавление", UserService.userToSave.Login, DateTime.Now, "Отдел", namedep);

                    result = "Новый департамент успешно добавлен";
                    context.SaveChanges();
                }
                else
                {
                    result = "Департамент уже существует";
                }

            }
            return result;
        }
        public static string EditDepartament(Departament olddepartament, string namedep)
        {
            string result = "Ошибка";
            using(InventoryСontrolEntities1 context = new InventoryСontrolEntities1())
            {
                var departament = context.Departament.FirstOrDefault(p => p.id_departament == olddepartament.id_departament);
                if (departament != null)
                {
                    departament.name_departament = namedep;
                    Service.LoggerService.AddLog("Редактирование", UserService.userToSave.Login, DateTime.Now, "Отдел", olddepartament.name_departament);

                    context.SaveChanges();
                    result = "Департамент успешно изменен";
                }
                else
                {
                    result = "Передан null;(";
                }
            }
            return result;
        }
        public static string DeleteDepartament(Departament departament)
        {
            string result = "Ошибка";
            using (InventoryСontrolEntities1 context = new InventoryСontrolEntities1())
            {
                var departamenttodelete = context.Departament.FirstOrDefault(p => p.id_departament == departament.id_departament);
                if(departament != null)
                {
                    context.Departament.Remove(departamenttodelete);
                    Service.LoggerService.AddLog("Удаление", UserService.userToSave.Login, DateTime.Now, "Отдел", departament.name_departament);

                    context.SaveChanges();
                    result = "Департамент успешно удален";
                }
                else
                {
                    result = "передан null";
                }
            }
            return result;
        }

    }
}

using InventoryControl.BdWork;
using InventoryControl.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Classes
{
    class Filters
    {
        public static ObservableCollection<WarehouseEquipment> FiltersWareHouse(string name, Brand brand, TypeOfEquipment type, string count)
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var Collection = new ObservableCollection<WarehouseEquipment>();
            var items = new List<WarehouseEquipment>();
            if (name != null || brand != null || type != null || count != null)
            {
                if (name == null && brand != null && type != null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.count == count && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (brand == null && name != null && type != null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.count == count && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                else if (brand != null && name != null && type == null && count != null)
                {

                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.count == count && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (brand != null && name != null && type != null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (name == null && brand == null && type != null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.count == count && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                // name
                else if (name != null && brand != null && type == null && count == null)
                {

                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (name != null && brand == null && type == null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.count == count).ToList();

                }

                else if (name != null && brand == null && type != null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                // gdfgdf
                // brand
                else if (name == null && brand != null && type == null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.Brand.namebrand == brand.namebrand && p.count == count).ToList();

                }

                else if (name == null && brand != null && type != null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.Brand.namebrand == brand.namebrand && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                // type

                else if (name != null && brand == null && type == null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name) && p.count == count).ToList();

                }
                // по одному
                else if (name != null && brand == null && type == null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.name.Contains(name)).ToList();

                }
                else if (name == null && brand != null && type == null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (name == null && brand == null && type != null && count == null)
                {
                    items = context.WarehouseEquipment.Where(p => p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                else if (name == null && brand == null && type == null && count != null)
                {
                    items = context.WarehouseEquipment.Where(p => p.count == count).ToList();

                }

            }

            if (items != null)
            {
                foreach (var item in items)
                {

                    Collection.Add(item);
                }

            }

            return Collection;
        }
        public static ObservableCollection<Orders> FiltersOrders(string name, Brand brand, TypeOfEquipment type)
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var Collection = new ObservableCollection<Orders>();
            var items = new List<Orders>();
            if (name != null || brand != null || type != null)
            {
                if (name == null && brand != null && type != null)
                {
                    items = context.Orders.Where(p => p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (brand == null && name != null && type != null)
                {
                    items = context.Orders.Where(p => p.Equipment.name.Contains(name) && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                else if (brand != null && name != null && type == null)
                {

                    items = context.Orders.Where(p => p.Equipment.name.Contains(name) && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (brand != null && name != null && type != null)
                {
                    items = context.Orders.Where(p => p.Equipment.name.Contains(name) && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (name == null && brand == null && type != null)
                {
                    items = context.Orders.Where(p => p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                // name
                else if (name != null && brand != null && type == null)
                {

                    items = context.Orders.Where(p => p.Equipment.name.Contains(name) && p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (name != null && brand == null && type == null)
                {
                    items = context.Orders.Where(p => p.Equipment.name.Contains(name)).ToList();

                }

                else if (name != null && brand == null && type != null)
                {
                    items = context.Orders.Where(p => p.Equipment.name.Contains(name) && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                // gdfgdf
                // brand
                else if (name == null && brand != null && type == null)
                {
                    items = context.Orders.Where(p => p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }

                else if (name == null && brand != null && type != null)
                {
                    items = context.Orders.Where(p => p.Equipment.Brand.namebrand == brand.namebrand && p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }
                // type

                else if (name != null && brand == null && type == null)
                {
                    items = context.Orders.Where(p => p.Equipment.name.Contains(name)).ToList();

                }
                // по одному
                else if (name != null && brand == null && type == null)
                {
                    items = context.Orders.Where(p => p.Equipment.name.Contains(name)).ToList();

                }
                else if (name == null && brand != null && type == null)
                {
                    items = context.Orders.Where(p => p.Equipment.Brand.namebrand == brand.namebrand).ToList();

                }
                else if (name == null && brand == null && type != null)
                {
                    items = context.Orders.Where(p => p.Equipment.TypeOfEquipment.NameTypeEquip == type.NameTypeEquip).ToList();

                }


            }

            if (items != null)
            {
                foreach (var item in items)
                {

                    Collection.Add(item);
                }

            }

            return Collection;
        }
        public static ObservableCollection<DepartamentEquipment> FilterDepartamentEquip(Brand selectedBrand, Departament departament, TypeOfEquipment selectedType, string nameFilter)
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            List<DepartamentEquipment> list = new List<DepartamentEquipment>();

            var newcollection = new ObservableCollection<DepartamentEquipment>();

            if (departament != null)
            {
                List<DepartamentEquipment> withThatDepartament = new List<DepartamentEquipment>();
                withThatDepartament = context.DepartamentEquipment.Where(p => p.Departament.name_departament == departament.name_departament).ToList();
                foreach (var item in withThatDepartament)
                {
                    list.Add(item);
                }
                if (selectedBrand != null)
                {
                    List<DepartamentEquipment> withThatBrand = new List<DepartamentEquipment>();
                    withThatBrand = context.DepartamentEquipment.Where(p => p.Equipment.Brand.namebrand != selectedBrand.namebrand).ToList();
                    foreach (var item in list.ToList())
                    {
                        if (withThatBrand.Contains(item))
                        {
                            list.Remove(item);

                        }
                    }
                }
                if (selectedType != null)
                {
                    List<DepartamentEquipment> withThatType = new List<DepartamentEquipment>();
                    withThatType = context.DepartamentEquipment.Where(p => p.Equipment.TypeOfEquipment.NameTypeEquip != selectedType.NameTypeEquip).ToList();
                    foreach (var item in list.ToList())
                    {
                        if (withThatType.Contains(item))
                        {
                            list.Remove(item);
                        }
                    }
                }
                if (!string.IsNullOrWhiteSpace(nameFilter))
                {
                    List<DepartamentEquipment> withThatName = new List<DepartamentEquipment>();
                    withThatName = context.DepartamentEquipment.Where(p => !p.Equipment.name.ToLower().Contains(nameFilter.ToLower())).ToList();
                    foreach (var item in list.ToList())
                    {
                        if (withThatName.Contains(item))
                        {
                            list.Remove(item);
                        }
                    }
                }
            }
            foreach (var item in list)
            {
                newcollection.Add(item);
            }
            return newcollection;
        }
        public static ObservableCollection<ComingRecords> FilterRecordsComing(Brand selectedBrand, Employers selectedEmployes, TypeOfEquipment selectedType, string nameFilter, string selectedDate)
        {
            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            List<ComingRecords> list = new List<ComingRecords>();

            var newcollection = new ObservableCollection<ComingRecords>();


            List<ComingRecords> withThatDepartament = new List<ComingRecords>();
            withThatDepartament = context.ComingRecords.ToList();
            foreach (var item in withThatDepartament)
            {
                list.Add(item);
            }
            if (selectedBrand != null)
            {
                List<ComingRecords> withThatBrand = new List<ComingRecords>();
                withThatBrand = context.ComingRecords.Where(p => p.Equipment.Brand.id_brand != selectedBrand.id_brand).ToList();
                foreach (var item in list.ToList())
                {
                    if (withThatBrand.Contains(item))
                    {
                        list.Remove(item);

                    }
                }
            }
            if (selectedType != null)
            {
                List<ComingRecords> withThatType = new List<ComingRecords>();
                withThatType = context.ComingRecords.Where(p => p.Equipment.TypeOfEquipment.id_typeEquip != selectedType.id_typeEquip).ToList();
                foreach (var item in list.ToList())
                {
                    if (withThatType.Contains(item))
                    {
                        list.Remove(item);
                    }
                }
            }
            if (selectedEmployes != null)
            {
                List<ComingRecords> withThatType = new List<ComingRecords>();
                withThatType = context.ComingRecords.Where(p => p.Employers.FioEmp != selectedEmployes.FioEmp).ToList();
                foreach (var item in list.ToList())
                {
                    if (withThatType.Contains(item))
                    {
                        list.Remove(item);
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                List<ComingRecords> withThatName = new List<ComingRecords>();
                withThatName = context.ComingRecords.Where(p => !p.Equipment.name.ToLower().Contains(nameFilter.ToLower())).ToList();
                foreach (var item in list.ToList())
                {
                    if (withThatName.Contains(item))
                    {
                        list.Remove(item);
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(selectedDate))
            {
                List<ComingRecords> withThatDate = new List<ComingRecords>();
                withThatDate = context.ComingRecords.Where(p => p.DateChanging != selectedDate).ToList();
                foreach (var item in list.ToList())
                {
                    if (withThatDate.Contains(item))
                    {
                        list.Remove(item);
                    }
                }
            }
            foreach (var item in list)
            {
                newcollection.Add(item);
            }
            return newcollection;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryControl.BdWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComingRecords
    {
        public int id_comingRecords { get; set; }
        public Nullable<int> Equipment_id { get; set; }
        public Nullable<int> CountEquip { get; set; }
        public string NumberOfNakladnay { get; set; }
        public string DateChanging { get; set; }
        public Nullable<int> Emp_id { get; set; }
        public Nullable<int> Rashod { get; set; }
        public Nullable<int> Ostatok { get; set; }
    
        public virtual Employers Employers { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}

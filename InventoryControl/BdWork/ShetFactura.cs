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
    
    public partial class ShetFactura
    {
        public int id_shetFactura { get; set; }
        public Nullable<int> seller_id { get; set; }
        public Nullable<int> Shipper_id { get; set; }
        public Nullable<int> place_id { get; set; }
        public Nullable<int> Currency_id { get; set; }
        public Nullable<int> nakladnay_id { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual Nakladnay Nakladnay { get; set; }
        public virtual PlacePriemka PlacePriemka { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual Shipper Shipper { get; set; }
    }
}

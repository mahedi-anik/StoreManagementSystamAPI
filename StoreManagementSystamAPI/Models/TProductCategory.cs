using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystamAPI.Models
{
    public partial class TProductCategory
    {
        public TProductCategory()
        {
            TProducts = new HashSet<TProduct>();
            TPurchases = new HashSet<TPurchase>();
            TSales = new HashSet<TSale>();
        }

        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryDescription { get; set; }
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        public virtual ICollection<TProduct> TProducts { get; set; }
        public virtual ICollection<TPurchase> TPurchases { get; set; }
        public virtual ICollection<TSale> TSales { get; set; }
    }
}

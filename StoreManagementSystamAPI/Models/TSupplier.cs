using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystemAPI.Models
{
    public partial class TSupplier
    {
        public TSupplier()
        {
            TProducts = new HashSet<TProduct>();
            TPurchases = new HashSet<TPurchase>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string SupplierDescription { get; set; }
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        public virtual ICollection<TProduct> TProducts { get; set; }
        public virtual ICollection<TPurchase> TPurchases { get; set; }
    }
}

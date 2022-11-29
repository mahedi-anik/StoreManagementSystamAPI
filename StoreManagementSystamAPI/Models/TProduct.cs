using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystemAPI.Models
{
    public partial class TProduct
    {
        public TProduct()
        {
            TPurchases = new HashSet<TPurchase>();
            TSales = new HashSet<TSale>();
        }

        public int ProductId { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? ShelfId { get; set; }
        public string ProductName { get; set; }
        public string BatchNo { get; set; }
        public int? SupplierId { get; set; }
        public double? BuyingPrice { get; set; }
        public double? SellingPrice { get; set; }
        public string ProductDescription { get; set; }
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        public virtual TProductCategory ProductCategory { get; set; }
        public virtual TShelf Shelf { get; set; }
        public virtual TSupplier Supplier { get; set; }
        public virtual ICollection<TPurchase> TPurchases { get; set; }
        public virtual ICollection<TSale> TSales { get; set; }
    }
}

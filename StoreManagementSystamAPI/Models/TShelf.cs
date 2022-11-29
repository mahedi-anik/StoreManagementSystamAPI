using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystemAPI.Models
{
    public partial class TShelf
    {
        public TShelf()
        {
            TProducts = new HashSet<TProduct>();
        }

        public int ShelfId { get; set; }
        public string ShelfName { get; set; }
        public double? NumericNo { get; set; }
        public string ShelfDescription { get; set; }
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        public virtual ICollection<TProduct> TProducts { get; set; }
    }
}

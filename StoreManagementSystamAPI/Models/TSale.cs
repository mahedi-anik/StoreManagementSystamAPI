using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystamAPI.Models
{
    public partial class TSale
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductCategoryId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Code { get; set; }
        public int? ProductId { get; set; }
        public double? Quantity { get; set; }
        public double? Amount { get; set; }
        public double? Discount { get; set; }
        public double? GrandAmount { get; set; }
        public int? PaymentMoodId { get; set; }
        public int? Status { get; set; }
        public double? BuyingPrice { get; set; }
        public string BatchNo { get; set; }
        public string Description { get; set; }
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        public virtual TCustomer Customer { get; set; }
        public virtual TPaymentMood PaymentMood { get; set; }
        public virtual TProduct Product { get; set; }
        public virtual TProductCategory ProductCategory { get; set; }
    }
}

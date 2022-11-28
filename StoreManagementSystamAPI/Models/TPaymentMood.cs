using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystamAPI.Models
{
    public partial class TPaymentMood
    {
        public TPaymentMood()
        {
            TPurchases = new HashSet<TPurchase>();
            TSales = new HashSet<TSale>();
        }

        public int Id { get; set; }
        public string PaymentMood { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TPurchase> TPurchases { get; set; }
        public virtual ICollection<TSale> TSales { get; set; }
    }
}

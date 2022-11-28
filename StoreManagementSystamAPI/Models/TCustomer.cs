using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystamAPI.Models
{
    public partial class TCustomer
    {
        public TCustomer()
        {
            TSales = new HashSet<TSale>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }

        public virtual ICollection<TSale> TSales { get; set; }
    }
}

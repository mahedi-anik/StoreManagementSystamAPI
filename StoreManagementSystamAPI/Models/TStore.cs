using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystemAPI.Models
{
    public partial class TStore
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public byte[] Image { get; set; }
        public string Currency { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}

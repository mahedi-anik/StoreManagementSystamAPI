using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystamAPI.Models
{
    public partial class TAdmin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EntryBy { get; set; }

        public virtual TUserRole Role { get; set; }
    }
}

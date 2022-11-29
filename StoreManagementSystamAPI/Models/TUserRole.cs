using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystemAPI.Models
{
    public partial class TUserRole
    {
        public TUserRole()
        {
            TAdmins = new HashSet<TAdmin>();
            TRolesMenus = new HashSet<TRolesMenu>();
        }

        public int UserRoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EntryBy { get; set; }

        public virtual ICollection<TAdmin> TAdmins { get; set; }
        public virtual ICollection<TRolesMenu> TRolesMenus { get; set; }
    }
}

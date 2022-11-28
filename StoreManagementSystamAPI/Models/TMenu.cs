using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystamAPI.Models
{
    public partial class TMenu
    {
        public TMenu()
        {
            InverseParent = new HashSet<TMenu>();
            TRolesMenus = new HashSet<TRolesMenu>();
        }

        public int Id { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EntryBy { get; set; }

        public virtual TMenu Parent { get; set; }
        public virtual ICollection<TMenu> InverseParent { get; set; }
        public virtual ICollection<TRolesMenu> TRolesMenus { get; set; }
    }
}

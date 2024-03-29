﻿using System;
using System.Collections.Generic;

#nullable disable

namespace StoreManagementSystemAPI.Models
{
    public partial class TRolesMenu
    {
        public int RolesMenuId { get; set; }
        public int? RoleId { get; set; }
        public int? MenuId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string EntryBy { get; set; }

        public virtual TMenu Menu { get; set; }
        public virtual TUserRole Role { get; set; }
    }
}

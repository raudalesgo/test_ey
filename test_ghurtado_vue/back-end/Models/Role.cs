using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleDscr { get; set; } = null!;
        public bool RoleActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

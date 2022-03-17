using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class User
    {
        public User()
        {
            Functionaries = new HashSet<Functionary>();
        }

        public string UserName { get; set; } = null!;
        public string UserPass { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public int RoleId { get; set; }
        public bool UserActive { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Functionary> Functionaries { get; set; }
    }
}

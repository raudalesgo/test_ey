using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class Rank
    {
        public Rank()
        {
            Functionaries = new HashSet<Functionary>();
        }

        public int RankCd { get; set; }
        public string RankDscr { get; set; } = null!;
        public bool RankActive { get; set; }

        public virtual ICollection<Functionary> Functionaries { get; set; }
    }
}

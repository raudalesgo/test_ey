using System;
using System.Collections.Generic;

namespace back_end.Models
{
    public partial class Functionary
    {
        public string FunctionaryGpn { get; set; } = null!;
        public string FunctionaryShtName { get; set; } = null!;
        public string? FunctionaryLngName { get; set; }
        public string FunctionaryEmail { get; set; } = null!;
        public int FunctionaryRankCd { get; set; }
        public bool? FunctionaryActive { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual Rank FunctionaryRankCdNavigation { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class ProductImg
    {
        public int Pimgid { get; set; }
        public string? Pid { get; set; }
        public string? Url { get; set; }

        public virtual Product? PidNavigation { get; set; }
    }
}

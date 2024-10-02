using System;
using System.Collections.Generic;

namespace BilliardShop.Models
{
    public partial class Blog
    {
        public int Blid { get; set; }
        public string? Bldtitle { get; set; }
        public string? Blcontent { get; set; }
        public bool? Status { get; set; }
        public DateTime? Createdate { get; set; }
        public string? Blimage { get; set; }
    }
}

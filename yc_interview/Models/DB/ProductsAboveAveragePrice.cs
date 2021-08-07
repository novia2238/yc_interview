using System;
using System.Collections.Generic;

#nullable disable

namespace yc_interview.Models.DB
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}

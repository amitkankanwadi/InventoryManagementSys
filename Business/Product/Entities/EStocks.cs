using System;

namespace Business.Product.Entities
{
    public class EStocks
    {
        public string ProductName { get; set; }
        public string Units { get; set; }
        public string UnitsSold { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

    }
}
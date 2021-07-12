using System;
using System.Collections.Generic;

namespace Business.Product.Entities
{
    public class EProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public float ProductRate { get; set; }
        public DateTime ProductAdded { get; set; }
    }
}
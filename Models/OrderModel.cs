using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileStoreV3.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
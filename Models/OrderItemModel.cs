using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileStoreV3.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MobilePhoneId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileStoreV3.Models
{
    public class AddMobilePhoneModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
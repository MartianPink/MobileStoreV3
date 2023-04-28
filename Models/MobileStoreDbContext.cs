using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MobileStoreV3.Models
{

    public class MobileStoreDbContext : DbContext
    {
        public MobileStoreDbContext() : base("MobilePhoneStoreContext")
        {
        }

        public DbSet<MobilePhoneModel> MobilePhones { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderItemModel> OrderItems { get; set; }
    }

}
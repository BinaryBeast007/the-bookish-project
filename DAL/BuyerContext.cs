using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class BuyerContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}

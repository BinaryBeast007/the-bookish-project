using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class RiderContext : DbContext
    {
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
    }
}

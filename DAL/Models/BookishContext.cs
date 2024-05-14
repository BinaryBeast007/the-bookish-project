using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class BookishContext :DbContext
    {

        public DbSet<Books> Books { get; set; }
        public DbSet<Categories> Categories {  get; set; }
        
        public DbSet<Authors> Authors { get; set; }
    }
}

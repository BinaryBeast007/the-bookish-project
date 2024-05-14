using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BooksDTO
    {
     
        public int Id { get; set; }
       
        public string Name { get; set; }

        
        public string Price { get; set; }


        public int Author_id { get; set; }

       
    }

}

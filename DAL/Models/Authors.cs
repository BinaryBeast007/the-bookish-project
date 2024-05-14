using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Authors
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }


        [Required]
        [StringLength(20)]
        public string Number { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
    }

}

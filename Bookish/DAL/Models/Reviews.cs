using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Rider")]
        public int RiderId { get; set; }
        [Required]
        public DateTime ReviewDate { get; set; }
        [Required]
        public int rating { get; set; }
        [Required]
        [StringLength(50)]
        public string review_text { get; set; }
        public virtual Rider Rider { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int TotalAmount { get; set; }
        [Required]
        [StringLength(50)]
        public string OrderStatus { get; set; }
        [Required]
        [StringLength(50)]
        public string DeliveryAddress { get; set; }
        [Required]
        [StringLength(50)]
        public string PaymentStatus { get; set; }
        public virtual Buyer Buyer { get; set; }
    }
}

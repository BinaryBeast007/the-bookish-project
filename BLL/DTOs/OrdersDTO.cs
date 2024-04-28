using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        [Required]
        public int BuyerId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int TotalAmount { get; set; }
        [Required]
        public string OrderStatus { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public string PaymentStatus { get; set; }
    }
}

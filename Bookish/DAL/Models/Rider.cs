﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Rider
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string AvailabilityStatus { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public Rider()
        {
            Reviews = new List<Reviews>();
        }
    }
}

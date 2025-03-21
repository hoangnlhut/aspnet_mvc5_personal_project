﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1WelcomeApp.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public byte DiscountRate { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1WelcomeApp.Models
{
    public class Customer
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public bool IsSubsribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
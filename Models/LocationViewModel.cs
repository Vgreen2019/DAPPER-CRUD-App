﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Models
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }
        public string GymName { get; set; }
        public string OpenAfter10PM { get; set; }
        public decimal MembershipPrice { get; set; }
        public string City { get; set; }
    }
}

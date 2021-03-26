﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int RoomId { get; set; }
        public string Status { get; set; }
        public string BookingBy { get; set; }
    }
}

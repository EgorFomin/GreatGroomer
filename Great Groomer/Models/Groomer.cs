using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Great_Groomer.Models
{
    public class Groomer
    {
        [Key]
        public int GroomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime GroomerDOB { get; set; }

        // Described in CENTS per hour (i.e. $25/hr = 2500cents/hr)
        public int GroomerRate { get; set; }

        // One Groomer to many GroomBooking
        public ICollection<GroomBooking> GroomBookings { get; set; }
    }
}
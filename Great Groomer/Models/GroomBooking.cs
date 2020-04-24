using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Great_Groomer.Models
{
    public class GroomBooking
    {
        [Key]
        public int GroomBookingID { get; set; }
        public DateTime GroomBookingDate { get; set; }
        public int GroomBookingPrice { get; set; } = 0; // cents

        // One Pet to Many Bookings
        public int PetID { get; set; }
        [ForeignKey("PetID")]
        public virtual Pet Pet { get; set; }

        //Representing the Many in (One Groomer to Many Bookings)
        public int GroomerID { get; set; }
        [ForeignKey("GroomerID")]
        public virtual Groomer Groomer { get; set; }

        //Representing the Many in (One Owner to Many Bookings)
        public int OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public virtual Owner Owner { get; set; }

        // One Booking Groomer to One Service)
        public int GroomServiceID { get; set; }
        [ForeignKey("GroomServiceID")]
        public virtual GroomService GroomService { get; set; }
    }
}
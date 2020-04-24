using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Great_Groomer.Models
{
    public class Owner
    {
        [Key]
        public int OwnerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }

        // One Booking to many Owners
        public ICollection<GroomBooking> GroomBookings { get; set; }

        // Many Owners to Many Pets
        public ICollection<Pet> Pets { get; set; }
    }
}
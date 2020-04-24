using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Great_Groomer.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; } // kg
        public string Color { get; set; }
        public string Notes { get; set; }

        // One Pet to one Owner
        public int OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public Owner Owners { get; set; }

        // Many Pet to One Species   
        public int SpeciesID { get; set; }
        [ForeignKey("SpeciesID")]
        public virtual Species Species { get; set; }

        // One Pet to many bookings
        public ICollection<GroomBooking> GroomBookings { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Great_Groomer.Models
{
    public class GroomService
    {
        [Key]
        public int GroomServiceID { get; set; }
        public string ServiceName { get; set; }
        public int ServiceCost { get; set; } // cents

        //Service duration established as minutes (i.e. 90min = 1hour30min)
        public int ServiceDuration { get; set; }

        //Representing the Many in (Many services to many Bookings)
        public ICollection<GroomBooking> GroomBookings { get; set; }
    }
}
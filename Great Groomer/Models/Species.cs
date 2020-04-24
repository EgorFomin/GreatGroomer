using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Great_Groomer.Models
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }

        public string SpeciesName { get; set; }

        //Representing the "Many" in (One Species to many Pets)
        public ICollection<Pet> Pets { get; set; }
    }
}
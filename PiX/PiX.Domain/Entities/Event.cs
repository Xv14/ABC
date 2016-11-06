using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class Event
    {
        [Key]
        public int idEvenement { get; set; }
        public string nameEvent { get; set; }
        public string description { get; set; }

        public int idAgent { get; set; }
        public Agent agent { get; set; }


        public WitnessCardTreated Card { get; set; }
        //public virtual ICollection<WitnessCardTreated> witnesscards { get; set; }
        public virtual ICollection<User> registredusers { get; set; }
    }
}

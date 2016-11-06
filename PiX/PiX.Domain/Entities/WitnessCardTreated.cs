using PiX.Domain.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class WitnessCardTreated : WitnessCard
    {
        public Address address { get; set; }
        public int etat { get; set; }

        public int idAgent { get; set; }
        public Agent agent { get; set; }

        public virtual ICollection<Event> events { get; set; }

        //added the subscribed users
        public virtual ICollection<User> Subscribers { get; set; }

    }
}

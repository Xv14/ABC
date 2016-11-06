using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class Agent : User
    {
        public string AgencyName { get; set; }
        public ICollection<string> ScannedDocuments { get; set; }
        public bool Active { get; set; }

        //navigation properties
        public virtual ICollection<WitnessCardTreated> SupervisedCards { get; set; }
        public virtual ICollection<Event> ManagedEvents { get; set; }
    }
}

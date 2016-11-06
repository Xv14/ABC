using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        //Navigation properties
        public virtual ICollection<Criteria> Criterias { get; set; }
        public virtual ICollection<WitnessCard> Cards { get; set; }

    }
}

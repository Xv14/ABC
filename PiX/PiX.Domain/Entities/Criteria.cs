using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class Criteria
    {
        public int CriteriaId { get; set; }
        public string Name { get; set; }

        //Navigation properties
        public Category Category { get; set; }
    }
}

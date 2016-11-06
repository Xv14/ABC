using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class AnalysisDictionary
    {
        public int AnalysisDictionaryId { get; set; }
        public virtual ICollection<string> HappyWords { get; set; }
        public virtual ICollection<string> SadWords { get; set; }

    }
}

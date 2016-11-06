using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class WitnessCard
    {
        [Key]
        public int idWitnessCard { get; set; }
        [Required]
        public string description { get; set; }
        public Category category { get; set; }
        
        //added the user
        public User User { get; set; }
    }
}

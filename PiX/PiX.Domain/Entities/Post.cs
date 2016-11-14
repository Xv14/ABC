using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class Post
    {

        private static int post_Counter = 0;

        public int PostId { get; set; }
        //public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PostDateTime { get; set; }
        public Privacy Privacy { get; set; }
        public string Image { get; set; }

        //Const
        public Post(){
            this.PostId = System.Threading.Interlocked.Increment(ref post_Counter);
        }
        

        //Navigation proeprties
        public virtual ICollection<Comment> Comments { get; set; }
        public User User { get; set; }
    }

    public enum Privacy
    {
        Public=0,
        Private=1
    }
}

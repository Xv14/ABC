using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaType MediaType { get; set; }

        //Navigation proeprties
        public virtual ICollection<Comment> Comments { get; set; }
        public User User { get; set; }
    }

    public enum MediaType
    {
        Image,
        Video,
        Text
    }
}

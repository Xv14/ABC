using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public EtatComment Etat { get; set; }

        //Navigation preperties
        public User User { get; set; }
        public Post Post { get; set; }
        public WitnessCardTreated Card { get; set; }
    }

    public enum EtatComment
    {
        Good,
        Bad
    }
}

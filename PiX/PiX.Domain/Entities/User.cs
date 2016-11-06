using PiX.Domain.ComplexType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiX.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Cin { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Tel { get; set; }
        public Address Address { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }

        //Navigation properties
        public virtual ICollection<User> FollowedUsers { get; set; }
        public virtual ICollection<User> Followers { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<WitnessCardTreated> FollowedCards { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        //public virtual ICollection<Event> FollowedEvents { get; set; }
        public virtual ICollection<Criteria> ChosenCriterias { get; set; }

    }
}

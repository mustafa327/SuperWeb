using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperWeb.Models
{
    public class UserFollow
    {
        [Key]
        public Guid ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("UserFollow")]
        public int UserFollowID { get; set; }



        public DateTime CreatedAt { get; set; }

        public virtual User Follower { get; set; }

        public virtual User Following { get; set; }

    }
}

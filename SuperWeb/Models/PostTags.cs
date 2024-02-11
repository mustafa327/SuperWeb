using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperWeb.Models
{
    public class PostTags
    {
        [Key]
        public Guid ID { get; set; }
        [ForeignKey("Post")]
        public Guid PostID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }

    }
}

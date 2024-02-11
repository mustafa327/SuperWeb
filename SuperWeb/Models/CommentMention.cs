using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperWeb.Models
{
    public class CommentMention
    {
        [Key]
        public Guid ID { get; set; }

        [ForeignKey("Comment")]
        public Guid CommentID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual PostComment Comment { get; set; }
        public virtual User MentionedUser { get; set; }
    }
}

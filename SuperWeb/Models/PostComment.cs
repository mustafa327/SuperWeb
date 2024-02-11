using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperWeb.Models
{
    public class PostComment
    {
        [Key]
        public Guid ID { get; set; }

        [ForeignKey("Parent")]
        public Guid ParentID { get; set; }

        [ForeignKey("Post")]
        public Guid PostID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CommentMention> Mentions { get; set; }
        public virtual ICollection<PostComment> Replies { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperWeb.Models
{
    public class Post
    {
        [Key]
        public Guid ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public int ViewCount { get; set; }
        public int LikesCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PostLikes> Likes { get; set; }
        public virtual ICollection<PostComment> Comments { get; set; }

        public virtual ICollection<PostTags> Tags { get; set; }
    }
}

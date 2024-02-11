using System.ComponentModel.DataAnnotations;

namespace SuperWeb.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int PhoneNo { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public string ImageCode { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public bool Is2FAKeyEnabled { get; set; }
        public string Secret2FAKey { get; set; }
        public string RecoveryCodes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual ICollection<UserFollow> Followers { get; set;}
        public virtual ICollection<UserFollow> Followings { get; set; }
        public virtual ICollection<PostLikes> Likes { get; set; }
        public virtual ICollection<PostTags> Tags { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostComment> Comments { get; set; }

        public virtual ICollection<CommentMention> Mentions { get; set; }


    }
}

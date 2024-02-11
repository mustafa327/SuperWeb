using Microsoft.EntityFrameworkCore;
using SuperWeb.Models;

namespace SuperWeb.Data
{
    public class SuperDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<CommentMention> CommentMentions { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostLikes> PostLikes { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<UserFollow> UserFollows { get; set; }

        public SuperDbContext(DbContextOptions<SuperDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFollow>()
                .HasKey(uf => new { uf.UserID, uf.UserFollowID });

            modelBuilder.Entity<UserFollow>()
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.Followings)
                .HasForeignKey(uf => uf.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFollow>()
                .HasOne(uf => uf.Following)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.UserFollowID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasKey(p => p.ID);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostLikes>()
                .HasKey(pl => pl.ID);

            modelBuilder.Entity<PostLikes>()
                .HasOne(pl => pl.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(pl => pl.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostLikes>()
                .HasOne(pl => pl.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(pl => pl.PostID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostLikes>()
                .HasIndex(pl => new { pl.PostID, pl.UserID })
                .IsUnique();

            modelBuilder.Entity<PostComment>()
                .HasKey(pc => pc.ID);

            modelBuilder.Entity<PostComment>()
                .HasOne(pc => pc.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(pc => pc.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostComment>()
                .HasOne(pc => pc.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(pc => pc.PostID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostTags>()
                .HasKey(pt => pt.ID);

            modelBuilder.Entity<PostTags>()
                .HasOne(pt => pt.User)
                .WithMany(u => u.Tags)
                .HasForeignKey(pt => pt.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostTags>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.Tags)
                .HasForeignKey(pt => pt.PostID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommentMention>()
                .HasKey(cm => cm.ID);

            modelBuilder.Entity<CommentMention>()
                .HasOne(cm => cm.Comment)
                .WithMany(pc => pc.Mentions)
                .HasForeignKey(cm => cm.CommentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommentMention>()
                .HasOne(cm => cm.MentionedUser)
                .WithMany(mu => mu.Mentions)
                .HasForeignKey(cm => cm.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);

            base.OnModelCreating(modelBuilder);
        }
    }
}

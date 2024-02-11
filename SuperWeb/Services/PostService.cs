using SuperWeb.Data;
using SuperWeb.Models;

namespace SuperWeb.Services
{
    public class PostService 
    {
        private readonly SuperDbContext _dbContext;

        public PostService(SuperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Post CreatePost(int userId, string title, string description, int viewCount, int likesCount )
        {
            var post = new Post
            {
                ID = Guid.NewGuid(),
                UserID = userId,
                Title = title,
                Description = description,
                
                CreatedAt = DateTime.UtcNow,
                
                ViewCount = viewCount,
                LikesCount = likesCount,
                
            };
            

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return post;
        }

        public bool UpdatePost(Guid postId, string newdescription)
        {
            
            var post = _dbContext.Posts.Find(postId);

            if (post != null)
            {
                post.IsDeleted = false;
                post.Description = newdescription;
                post.UpdatedAt = DateTime.UtcNow;
                _dbContext.SaveChanges();
                return true;

            }
            return false;
        }

        public bool DeletePost(Guid postId)
        {
            var post = _dbContext.Posts.Find(postId);

            if (post != null)
            {
                post.DeletedAt = DateTime.UtcNow;
                post.IsDeleted = true;

                _dbContext.Posts.Remove(post);
                _dbContext.SaveChanges();
                return true;

            }
            return false;
        }
        public bool IncrementViewCount(Guid postId)
        {
            var post = _dbContext.Posts.Find(postId);

            if (post != null)
            {
                post.ViewCount++;
                _dbContext.SaveChanges();
                return true;

            }
            return false;

        }
        public bool LikePost(Guid postId, int userId)
        {
            var post = _dbContext.Posts.Find(postId);

            if (post != null)
            {
                // Check if the user has already liked the post
                var existingLike = _dbContext.PostLikes
                    .FirstOrDefault(pl => pl.PostID == postId && pl.UserID == userId);

                if (existingLike != null)
                {
                    // User has already liked the post, so unlike it
                    _dbContext.PostLikes.Remove(existingLike);
                    post.LikesCount--;
                }
                else
                {
                    // User has not liked the post, so like it
                    var newLike = new PostLikes
                    {
                        ID = Guid.NewGuid(),
                        UserID = userId,
                        PostID = postId,
                        CreatedAt = DateTime.UtcNow,


                    };
                    _dbContext.PostLikes.Add(newLike);
                    post.LikesCount++;
                }

                _dbContext.SaveChanges();
                return true;
            }

            return false;

        }
        public PostComment CreateComment(Guid postId, int userId, string comment)
        {
            var postComment = new PostComment
            {
                PostID = postId,
                UserID = userId,
                Comment = comment,
                CreatedAt = DateTime.UtcNow,
            };

            _dbContext.PostComments.Add(postComment);
            _dbContext.SaveChanges();

            return postComment;
        }

        public bool UpdateComment(Guid commentId, string newcomment)
        {
            var comment = _dbContext.PostComments.Find(commentId);

            if (comment != null)
            {
                comment.Comment = newcomment;
                comment.UpdatedAt = DateTime.UtcNow;
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteComment(int commentId)
        {
            var comment = _dbContext.PostComments.Find(commentId);

            if (comment != null)
            {
                comment.IsDeleted = true;
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}


using SuperWeb.Data;
using SuperWeb.Models;
using System.Linq;

namespace SuperWeb.Services
{
    public class UserService
    {
        private readonly SuperDbContext _dbContext;

        public UserService(SuperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void FollowUser(int followerId, int followingId)
        {
            // Check if the follow relationship already exists
            var existingFollow = _dbContext.UserFollows
                .FirstOrDefault(uf => uf.UserID == followerId && uf.UserFollowID == followingId);

            if (existingFollow == null)
            {
                var userFollow = new UserFollow
                {
                    UserID = followerId,
                    UserFollowID = followingId,
                    // Set other properties as needed
                };

                _dbContext.UserFollows.Add(userFollow);
                _dbContext.SaveChanges();
            }
            else{

                throw new InvalidOperationException("The follow relationship already exists.");
            }
        }

        public void UnfollowUser(int followerId, int followingId)
        {
            var userFollow = _dbContext.UserFollows
                .FirstOrDefault(uf => uf.UserID == followerId && uf.UserFollowID == followingId);

            if (userFollow != null)
            {
                _dbContext.UserFollows.Remove(userFollow);
                _dbContext.SaveChanges();
            }
            else
            {

                throw new InvalidOperationException("The follow relationship already doesn't exists.");
            }
            
        }
    }
}

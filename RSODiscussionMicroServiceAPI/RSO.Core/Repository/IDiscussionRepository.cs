using RSO.Core.DiscussionModels;

namespace RSO.Core.Repository;

public interface IDiscussionRepository : IGenericRepository<Discussion>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="discussionId"></param>
    /// <returns></returns>
    public Task DeleteDiscussionAsync(int discussionId);
}
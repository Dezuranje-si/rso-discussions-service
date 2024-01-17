using RSO.Core.DiscussionModels;

namespace RSO.Core.BL;

/// <summary>
/// Handles the user logic.
/// </summary>
public interface IDiscussionLogic
{
    /// <summary>
    /// Creates a new discussion.
    /// </summary>
    /// <param name="discussion"></param>
    /// <returns></returns>
    public Task<Discussion> CreateDiscussionAsync(Discussion discussion);

    /// <summary>
    /// Updates a discussion.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public Task<bool> UpdateDiscussionAsync(Discussion d);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public Task<bool> DeleteDiscussionAsync(Discussion d);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Discussion> GetDiscussionAsync(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<List<Discussion>> GetAllDiscussionsAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Task<List<Discussion>> GetDiscussionsByUserIdAsync(int userId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="adId"></param>
    /// <returns></returns>
    Task<List<Discussion>> GetDiscussionAsyncByAdIdAsync(int adId);
}

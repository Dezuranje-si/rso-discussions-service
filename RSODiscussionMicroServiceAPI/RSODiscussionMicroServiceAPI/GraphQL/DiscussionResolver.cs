using RSO.Core.BL;
using RSO.Core.DiscussionModels;

namespace RSODiscussionMicroServiceAPI.GraphQL;

[ExtendObjectType("Query")]
public class DiscussionQueryResolver
{
    public async Task<Discussion> GetDiscussionAsync(int id, IDiscussionLogic discussionLogic) => await discussionLogic.GetDiscussionAsync(id);

    //public async Task<List<Discussion>> GetAllDiscussionsAsync(IDiscussionLogic discussionLogic) => await discussionLogic.GetAllDiscussionsAsync();

    //public async Task<List<Discussion>> GetDiscussionsByUserIdAsync(IDiscussionLogic discussionLogic, int userId) => await discussionLogic.GetDiscussionsByUserIdAsync(userId);

    //public async Task<List<Discussion>> GetDiscussionsByAdAsync(IDiscussionLogic discussionLogic, int adId) => await discussionLogic.GetDiscussionAsyncByAdIdAsync(adId);
}

using RSO.Core.BL;
using RSO.Core.DiscussionModels;

namespace RSODiscussionMicroServiceAPI.GraphQL;

[ExtendObjectType("Query")]
public class DiscussionQueryResolver
{
    public async Task<Discussion> GetDiscussionAsync([Service] IDiscussionLogic discussionLogic, int id)
    {
        return await discussionLogic.GetDiscussionAsync(id);
    }

    public async Task<List<Discussion>> GetAllDiscussionsAsync([Service] IDiscussionLogic discussionLogic)
    {
        return await discussionLogic.GetAllDiscussionsAsync();
    }
}

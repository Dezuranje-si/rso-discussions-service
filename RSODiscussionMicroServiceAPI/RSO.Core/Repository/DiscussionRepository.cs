using Microsoft.EntityFrameworkCore;
using RSO.Core.DiscussionModels;

namespace RSO.Core.Repository;

/// <summary>
/// Implementation of <see cref="IDiscussionRepository"/> interface.
/// </summary>
public class DiscussionRepository : GenericRepository<Discussion>, IDiscussionRepository
{
    public DiscussionRepository(DiscussionServicesRSOContext context) : base(context) { }

    ///<inheritdoc/>
    public async Task DeleteDiscussionAsync(int discussionId) => await _context.Discussions.Where(Discussion => Discussion.DiscussionId == discussionId).ExecuteDeleteAsync();

}

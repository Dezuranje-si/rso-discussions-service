using Microsoft.EntityFrameworkCore;
using RSO.Core.UserModels;

namespace RSO.Core.Repository;

public class DiscussionRepository : GenericRepository<Discussion>, IDiscussionRepository
{
    public DiscussionRepository(DiscussionServicesRSOContext context) : base(context) { }
}

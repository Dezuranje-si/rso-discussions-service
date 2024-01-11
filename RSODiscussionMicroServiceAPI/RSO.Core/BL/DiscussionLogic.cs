using LazyCache;
using RSO.Core.Configurations;
using RSO.Core.Repository;

namespace RSO.Core.BL;

/// <summary>
/// Implementation of <see cref="IDiscussionLogic"/> interface.
/// </summary>
public class DiscussionLogic : IDiscussionLogic
{
    private readonly IAppCache _appcache;
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtSecurityTokenConfiguration _jwtConfiguration;

    /// <summary>
    /// Initializes the <see cref="DiscussionLogic"/> class.
    /// </summary>
    /// <param name="appcache"><see cref="IAppCache"/> instance.</param>
    /// <param name="unitOfWork"><see cref="IUnitOfWork"/> instance.</param>
    /// <param name="jwtConfiguration"><see cref="JwtSecurityTokenConfiguration"/> dependency injection.</param>
    public DiscussionLogic(IAppCache appcache, IUnitOfWork unitOfWork, JwtSecurityTokenConfiguration jwtConfiguration)
    {
        _appcache = appcache;
        _unitOfWork = unitOfWork;
        _jwtConfiguration = jwtConfiguration;
    }

    ///<inheritdoc/>
}

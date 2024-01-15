using RSO.Core.DiscussionModels;

namespace RSO.Core.Repository;

/// <summary>
/// Implements the <see cref="IUnitOfWork"/> interface.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly DiscussionServicesRSOContext _discussionServicesContext;
    private bool disposed;

    /// <summary>
    /// Constructor for the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="discussionServicesRSOContext ">The <see cref="userServicesRSOContext "/> context for the database access.</param>
    /// <param name="discussionRepository">IDiscussionRepository instance.</param>
    public UnitOfWork(DiscussionServicesRSOContext discussionServicesRSOContext, IDiscussionRepository discussionRepository)
    {
        _discussionServicesContext = discussionServicesRSOContext;
        DiscussionRepository = discussionRepository;
    }

    ///<inheritdoc/>
    public IDiscussionRepository DiscussionRepository { get; }

    ///<inheritdoc/>
    public async Task<int> SaveChangesAsync() => await _discussionServicesContext.SaveChangesAsync();

    /// <summary>
    /// Implements the <see cref="IDisposable"/> interface. Called when we'd like to the dispose the <see cref="UnitOfWork"/> object.
    /// </summary>
    /// <param name="disposing">The </param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _discussionServicesContext.Dispose();
            }
        }
        disposed = true;
    }

    /// <summary>
    /// Disposes the <see cref="UnitOfWork"/> object and acts as a wrapper for <see cref="Dispose(bool)"/> method.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

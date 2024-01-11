namespace RSO.Core.Repository;

/// <summary>
/// Handles the communication with the database.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// The repository that handles joined database tables.
    /// </summary>
    public IDiscussionRepository DiscussionRepository { get; }

    /// <summary>
    /// Applies the operation. Called after a Repository function is called.
    /// </summary>
    /// <returns>True if the operation was successful.</returns>
    public Task<int> SaveChangesAsync();
}

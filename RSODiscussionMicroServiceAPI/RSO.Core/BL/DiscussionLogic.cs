using RSO.Core.Configurations;
using RSO.Core.DiscussionModels;
using RSO.Core.Repository;

namespace RSO.Core.BL;

/// <summary>
/// Implementation of <see cref="IDiscussionLogic"/> interface.
/// </summary>
public class DiscussionLogic : IDiscussionLogic
{
    private readonly IUnitOfWork _unitOfWork;
    //private readonly JwtSecurityTokenConfiguration _jwtConfigurtion;

    /// <summary>
    /// Initializes the <see cref="DiscussionLogic"/> class.
    /// </summary>
    /// <param name="unitOfWork"><see cref="IUnitOfWork"/> instance.</param>
    public DiscussionLogic(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    ///<inheritdoc/>
    public async Task<Discussion> CreateDiscussionAsync(Discussion newDiscussion)
    {
        try
        {
            var discussion = await _unitOfWork.DiscussionRepository.InsertAsync(newDiscussion);
            await _unitOfWork.SaveChangesAsync();
            return discussion;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    ///<inheritdoc/>
    public async Task<bool> DeleteDiscussionAsync(Discussion d)
    {
        try
        {
            await _unitOfWork.DiscussionRepository.DeleteDiscussionAsync(d.DiscussionId);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

    ///<inheritdoc/>
    public async Task<List<Discussion>> GetAllDiscussionsAsync()
    {
        try
        {
            var discussions = await _unitOfWork.DiscussionRepository.GetAllAsync();
            return discussions.ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<Discussion>().ToList();
        }
    }

    ///<inheritdoc/>
    public async Task<Discussion> GetDiscussionAsync(int id)
    {
        try
        {
            return await _unitOfWork.DiscussionRepository.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<List<Discussion>> GetDiscussionAsyncByAdIdAsync(int adId)
    {
        try
        {
            var discussions = await _unitOfWork.DiscussionRepository.GetAllAsync();
            return discussions.Where(d => d.AddId == adId).ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<Discussion>().ToList();
        }
    }

    ///<inheritdoc/>
    public async Task<List<Discussion>> GetDiscussionsByUserIdAsync(int userId)
    {
        try
        {
            var discussions = await _unitOfWork.DiscussionRepository.GetAllAsync();
            return discussions.Where(d => d.UserId == userId).ToList();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<Discussion>().ToList();
        }
    }

    ///<inheritdoc/>
    public async Task<bool> UpdateDiscussionAsync(Discussion d)
    {
        try
        {
            var existingDiscussion = await _unitOfWork.DiscussionRepository.GetByIdAsync(d.DiscussionId);
            if (existingDiscussion is null)
                return false;

            existingDiscussion.DiscussionText = d.DiscussionText;
            existingDiscussion.DiscussionText = d.DiscussionText;

            await _unitOfWork.DiscussionRepository.UpdateAsync(existingDiscussion);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return false;
        }

        return true;
    }
}

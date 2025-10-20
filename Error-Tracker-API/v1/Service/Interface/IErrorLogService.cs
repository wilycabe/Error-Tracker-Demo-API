using Error_Tracker_API.v1.Dto;
using Error_Tracker_API.v1.Request;

namespace Error_Tracker_API.v1.Service.Interface
{
    /// <summary>
    /// Defines CRUD operations for managing error logs.
    /// </summary>
    public interface IErrorLogService
    {
        Task<IEnumerable<ErrorLogDto>> GetAllAsync();
        Task<ErrorLogDto?> GetByIdAsync(int id);
        Task<ErrorLogDto> CreateAsync(CreateErrorLogRequest request);
        Task<ErrorLogDto?> UpdateAsync(int id, UpdateErrorLogRequest request);
        Task<bool> DeleteAsync(int id);
    }
}

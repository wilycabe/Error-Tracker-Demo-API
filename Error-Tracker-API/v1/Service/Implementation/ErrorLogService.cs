using Error_Tracker_API.v1.Context;
using Error_Tracker_API.v1.Dto;
using Error_Tracker_API.v1.Entity;
using Error_Tracker_API.v1.Request;
using Error_Tracker_API.v1.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Error_Tracker_API.v1.Service.Implementation
{
    /// <summary>
    /// Implementation of IErrorLogService using EF Core and SQLite.
    /// </summary>
    public class ErrorLogService : IErrorLogService
    {
        private readonly ErrorDbContext _context;

        public ErrorLogService(ErrorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ErrorLogDto>> GetAllAsync()
        {
            return await _context.ErrorLogs
                .Select(e => new ErrorLogDto
                {
                    Id = e.Id,
                    Message = e.Message,
                    StackTrace = e.StackTrace,
                    Severity = e.Severity,
                    CreatedAt = e.CreatedAt,
                    ApplicationName = e.ApplicationName
                })
                .ToListAsync();
        }

        public async Task<ErrorLogDto?> GetByIdAsync(int id)
        {
            var entity = await _context.ErrorLogs.FindAsync(id);
            if (entity == null) return null;

            return new ErrorLogDto
            {
                Id = entity.Id,
                Message = entity.Message,
                StackTrace = entity.StackTrace,
                Severity = entity.Severity,
                CreatedAt = entity.CreatedAt,
                ApplicationName = entity.ApplicationName
            };
        }

        public async Task<ErrorLogDto> CreateAsync(CreateErrorLogRequest request)
        {
            var entity = new ErrorLog
            {
                Message = request.Message,
                StackTrace = request.StackTrace,
                Severity = request.Severity,
                ApplicationName = request.ApplicationName,
                CreatedAt = DateTime.UtcNow
            };

            _context.ErrorLogs.Add(entity);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(entity.Id) ?? throw new Exception("Error creating log");
        }

        public async Task<ErrorLogDto?> UpdateAsync(int id, UpdateErrorLogRequest request)
        {
            var entity = await _context.ErrorLogs.FindAsync(id);
            if (entity == null) return null;

            entity.Message = request.Message;
            entity.StackTrace = request.StackTrace;
            entity.Severity = request.Severity;
            entity.ApplicationName = request.ApplicationName;

            await _context.SaveChangesAsync();

            return await GetByIdAsync(entity.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ErrorLogs.FindAsync(id);
            if (entity == null) return false;

            _context.ErrorLogs.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

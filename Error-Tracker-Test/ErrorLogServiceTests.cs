using Error_Tracker_API.v1.Context;
using Error_Tracker_API.v1.Request;
using Error_Tracker_API.v1.Service.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Error_Tracker_Test
{
    /// <summary>
    /// Unit tests for the ErrorLogService class.
    /// </summary>
    public class ErrorLogServiceTests
    {
        private ErrorLogService GetService()
        {
            var options = new DbContextOptionsBuilder<ErrorDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new ErrorDbContext(options);
            return new ErrorLogService(context);
        }

        [Fact]
        public async Task CreateAsync_ShouldAddNewErrorLog()
        {
            var service = GetService();

            var request = new CreateErrorLogRequest { Message = "Test Error", Severity = "High" };
            var result = await service.CreateAsync(request);

            Assert.NotNull(result);
            Assert.Equal("Test Error", result.Message);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnLogs()
        {
            var service = GetService();

            await service.CreateAsync(new CreateErrorLogRequest { Message = "Error 1" });
            await service.CreateAsync(new CreateErrorLogRequest { Message = "Error 2" });

            var result = await service.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task UpdateAsync_ShouldModifyLog()
        {
            var service = GetService();
            var created = await service.CreateAsync(new CreateErrorLogRequest { Message = "Initial" });

            var updated = await service.UpdateAsync(created.Id, new UpdateErrorLogRequest { Message = "Updated" });

            Assert.NotNull(updated);
            Assert.Equal("Updated", updated.Message);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveLog()
        {
            var service = GetService();
            var created = await service.CreateAsync(new CreateErrorLogRequest { Message = "ToDelete" });

            var success = await service.DeleteAsync(created.Id);
            Assert.True(success);
        }
    }
}

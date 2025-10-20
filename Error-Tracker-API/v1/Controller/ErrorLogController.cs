using Error_Tracker_API.v1.Request;
using Error_Tracker_API.v1.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Error_Tracker_API.v1.Controller
{
    /// <summary>
    /// REST API Controller for managing error logs.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorLogsController : ControllerBase
    {
        private readonly IErrorLogService errorLogSrv;

        public ErrorLogsController(IErrorLogService service)
        {
            errorLogSrv = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await errorLogSrv.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await errorLogSrv.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateErrorLogRequest request)
        {
            var result = await errorLogSrv.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateErrorLogRequest request)
        {
            var result = await errorLogSrv.UpdateAsync(id, request);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await errorLogSrv.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}

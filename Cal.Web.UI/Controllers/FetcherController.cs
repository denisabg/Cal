using System;
using System.Threading.Tasks;
using Cal.Core.Abstraction;
using Cal.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cal.Web.UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FetcherController : ControllerBase
    {

        private readonly ILogger<FetcherController> _logger;
        private readonly IBookmarkService _bookmarkService;


        public FetcherController(
            ILogger<FetcherController> logger, 
            IBookmarkService bookmarkService)
        {
            _logger = logger;
            _bookmarkService = bookmarkService;
        }


        [HttpGet]
        public async Task<StatusState[]> GetStatusAsync()
        {
            try
            {
                var model = await _bookmarkService.FetchAsync();
                return model;
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);
                throw;
            }
            
        }

        [HttpPut]
        public async Task SetStateAsync(Guid id, [FromBody] State state)
        {
            try
            {
                await _bookmarkService.UpdateAsync(
                    new BookmarkContext(
                        new StatusState
                        {
                            Id = id,
                            DateStamp = DateTime.UtcNow,
                            State = state
                        }));
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);
            }
        }
    }
}
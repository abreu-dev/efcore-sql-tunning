using Microsoft.AspNetCore.Mvc;
using Tunning.Infra.Core.Context;

namespace Tunning.WebApi.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        private readonly IDataContext _dataContext;

        public HealthController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var isDatabaseAvailable = _dataContext.IsAvailable();

            var response = new
            {
                isDatabaseAvailable
            };

            if (isDatabaseAvailable)
                return Ok(response);

            return BadRequest(response);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeShare.TransferJob.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBackgroundRunService _backgroundRunService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBackgroundRunService backgroundRunService)
        {
            _logger = logger;
            _backgroundRunService = backgroundRunService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _backgroundRunService.Transfer(()=>Console.WriteLine(Guid.NewGuid().ToString()));
            _backgroundRunService.Transfer<IBaiduApi>(baidu=>baidu.GetBaidu());
            return Ok();
        }
    }
}

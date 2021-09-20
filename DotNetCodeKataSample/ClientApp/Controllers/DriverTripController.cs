using DriverTripLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetCodeKataSample.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class DriverTripController : ControllerBase
   {
      private readonly ILogger<DriverTripController> _logger;

      public DriverTripController(ILogger<DriverTripController> logger)
      {
         _logger = logger;
      }

      [HttpPost]
      public IEnumerable<DriverTripDetails> Post([FromBody] object inputStreamData)
      {
         var report = DriverTripReport.GetInstance;

         var streamDataArray = inputStreamData.ToString().Split("\"");

         return report.ProcessInputStream((streamDataArray.Length >= 4) ? streamDataArray[3] : null);
      }

   }
}

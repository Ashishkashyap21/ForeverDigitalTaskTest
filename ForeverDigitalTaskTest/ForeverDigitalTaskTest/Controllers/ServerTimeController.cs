using System;
using System.Web.Http;

namespace ForeverDigitalTaskTest.Controllers
{
    public class ServerTimeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new { ServerTime = DateTime.UtcNow.ToString("s", System.Globalization.CultureInfo.InvariantCulture) });
        }
    }
}

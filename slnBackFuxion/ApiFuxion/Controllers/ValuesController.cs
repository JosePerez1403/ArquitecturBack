using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ApiFuxion.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IActionResult LogError()
        {
            var exFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();


            if (exFeature != null)
            {

                string path = exFeature.Path;

                Exception ex = exFeature.Error;

                Log.Error(ex, path);

                var error = new { ErrorMessage = ex.Message, ErrorPath = path };

                return BadRequest(error);
            }

            return BadRequest();
        }
    }
}

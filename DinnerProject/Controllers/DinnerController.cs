using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers
{
    
    public class DinnerController : BaseController
    {
        [HttpGet("Dinners")]
        public IActionResult Dinners()
        {
            return Ok(new object[] { });
        }
    }
}

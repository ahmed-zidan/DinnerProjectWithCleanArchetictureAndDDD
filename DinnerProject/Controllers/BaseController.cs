
using Dinner.Application.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Dinner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected IActionResult Problem(ApiResponse error)
        {
            switch (error.StatusCode)
            {
                case 404:
                    {
                        return NotFound(error);
                    }
                case 401:
                    {
                        return Unauthorized(error);
                    }
                default:
                    {
                        return BadRequest(error);
                    }
            }
        }


    }


}

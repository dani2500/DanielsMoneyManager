using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DanielsMoneyManagerApi.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/api/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem(
                            title: exception?.Message,
                            statusCode: 500
                           );
        }
    }
}

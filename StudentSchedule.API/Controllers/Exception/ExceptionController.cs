using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentSchedule.API.Exception;

namespace StudentSchedule.API.Controllers.Exception;

[AllowAnonymous]
[ApiExplorerSettings(IgnoreApi = true)]
public class ExceptionController : ControllerBase
{
    // Credit/thanks to stackoverflow.com/users/2061604/andrei
    [Route("/error")]
    public IActionResult Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context!.Error;

        try
        {
            throw exception;
        }
        catch (AppException ex)
        {
            return Problem(
                statusCode: ex.StatusCode,
                detail: ex.Message
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch(System.Exception ex) 
        {
            return Problem(
                statusCode: 500,
                detail: ex.Message
            );
        }
    }
}
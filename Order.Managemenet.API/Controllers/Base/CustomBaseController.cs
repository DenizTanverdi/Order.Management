using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Management.Core.DTOs;

namespace Order.Management.API.Controllers.Base
{
    public class CustomBaseController : ControllerBase
    {
        [NonAction] // Endpoint olmadığından NonAction kullandık
        public IActionResult CreatActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
            
        }
    }
}

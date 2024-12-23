using Backend_prueba_tecnica.Core.DTOs;
using Backend_prueba_tecnica.Core.DTOs.Response;
using Backend_prueba_tecnica.Core.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_prueba_tecnica.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CrearUusarioAsync([FromBody] User request)
    {
        try
        {
            string msgUser = await _userService.CrearUsuarioAsync(request);
            return StatusCode(200, new BaseResponse
            {
                Message = msgUser,
                Exception = "0",
                Data = 0
            });
        }
        catch (Exception ex) 
        {
            return StatusCode(200, new BaseResponse
            {
                Message = "Consulta con errores",
                Exception = ex.Message,
                Data = 0
            });
        }
    }
}

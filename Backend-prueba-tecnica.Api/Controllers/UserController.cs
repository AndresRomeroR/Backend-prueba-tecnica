using Backend_prueba_tecnica.Core.DTOs;
using Backend_prueba_tecnica.Core.DTOs.Response;
using Backend_prueba_tecnica.Core.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
        if (string.IsNullOrEmpty(request.Nombre) || !Regex.IsMatch(request.Nombre, @"^[a-zA-Z\s]+$"))
            return StatusCode(400, new BaseResponse
            {
                Message = "Dato nombre con errores o no incluido",
                Exception = "",
                Data = 0
            });

        if (string.IsNullOrEmpty(request.Apellido) || !Regex.IsMatch(request.Apellido, @"^[a-zA-Z\s]+$"))
            return StatusCode(400, new BaseResponse
            {
                Message = "Dato apellido con errores o no incluido",
                Exception = "",
                Data = 0
            });

        if (string.IsNullOrEmpty(request.TipoDocumento) || !Regex.IsMatch(request.TipoDocumento, @"^[a-zA-Z\s]+$"))
            return StatusCode(400, new BaseResponse
            {
                Message = "Dato tipo documento con errores o no incluido",
                Exception = "",
                Data = 0
            });

        if (request.FechaNacimiento == DateTime.MinValue)
        {
            return StatusCode(400, new BaseResponse
            {
                Message = "Dato fecha con errores o no incluido",
                Exception = "",
                Data = 0
            });
        }

        if (request.IdEstadoCivil < 1 || request.IdEstadoCivil > 2)
            return StatusCode(400, new BaseResponse
            {
                Message = "Dato estado civil no existe",
                Exception = "",
                Data = 0
            });

        if (decimal.IsNegative(request.ValorAGanar))
            return StatusCode(400, new BaseResponse
            {
                Message = "Dato Valor a Ganar no puede ser negativo",
                Exception = "",
                Data = 0
            });

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

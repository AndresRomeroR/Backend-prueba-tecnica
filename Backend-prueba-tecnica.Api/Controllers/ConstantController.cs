using Backend_prueba_tecnica.Core.DTOs;
using Backend_prueba_tecnica.Core.DTOs.Response;
using Backend_prueba_tecnica.Core.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_prueba_tecnica.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConstantController : ControllerBase
{
    private readonly IEstadoCivilService _estadoCivilService;

    public ConstantController(IEstadoCivilService estadoCivilService)
    {
        _estadoCivilService = estadoCivilService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerEstadoCivilAsync()
    {
        try
        {
            List<EstadoCivil> estadosCivil = await _estadoCivilService.ObtenerEstadosCivilAsync();

            return StatusCode(200, new BaseResponse
            {
                Message = "Consulta realizada con exito",
                Exception = "0",
                Data = estadosCivil
            });
        }
        catch (Exception ex)
        {
            return StatusCode(400, new BaseResponse
            {
                Message = "Consulta con errores",
                Exception = ex.Message,
                Data = 0
            });
        }
    }
}

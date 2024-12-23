using Backend_prueba_tecnica.Core.DTOs;

namespace Backend_prueba_tecnica.Core.Interface.Service;

public interface IEstadoCivilService
{
    Task<List<EstadoCivil>> ObtenerEstadosCivilAsync();
}

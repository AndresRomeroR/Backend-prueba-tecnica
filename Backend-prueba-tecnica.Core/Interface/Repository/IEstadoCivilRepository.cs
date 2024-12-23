using Backend_prueba_tecnica.Core.DTOs;

namespace Backend_prueba_tecnica.Core.Interface.Repository;

public interface IEstadoCivilRepository
{
    Task<List<EstadoCivil>> ObtenerEstadosCivilAsync();
}

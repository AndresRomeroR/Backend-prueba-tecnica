using Backend_prueba_tecnica.Core.DTOs;
using Backend_prueba_tecnica.Core.Interface.Repository;
using Backend_prueba_tecnica.Core.Interface.Service;

namespace Backend_prueba_tecnica.Core.Service;

public class EstadoCivilService : IEstadoCivilService
{
    private readonly IEstadoCivilRepository _estadoCivilRepository;

    public EstadoCivilService(IEstadoCivilRepository estadoCivilRepository)
    {
        _estadoCivilRepository = estadoCivilRepository;
    }

    public async Task<List<EstadoCivil>> ObtenerEstadosCivilAsync()
    { 
        return await _estadoCivilRepository.ObtenerEstadosCivilAsync();
    }
}

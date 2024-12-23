using Backend_prueba_tecnica.Core.DTOs;

namespace Backend_prueba_tecnica.Core.Interface.Service;

public interface IUserService
{
    Task<string> CrearUsuarioAsync(User user);
}

using Backend_prueba_tecnica.Core.DTOs;

namespace Backend_prueba_tecnica.Core.Interface.Repository;

public interface IUserRepository
{
    Task<bool> CrearUsuarioAsync(User user);
}

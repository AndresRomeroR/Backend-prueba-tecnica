using Backend_prueba_tecnica.Core.DTOs;
using Backend_prueba_tecnica.Core.Interface.Repository;
using Backend_prueba_tecnica.Core.Interface.Service;

namespace Backend_prueba_tecnica.Core.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> CrearUsuarioAsync(User user)
    {
        bool userCreated = await _userRepository.CrearUsuarioAsync(user);
        if (userCreated)
        {
            return "Usuario Creado con exito";
        }
        else
        {
            return "Usuario no fue posible de crear";
        }
    }
}

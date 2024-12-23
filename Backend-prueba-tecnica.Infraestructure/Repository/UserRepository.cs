using Backend_prueba_tecnica.Core.DTOs;
using Backend_prueba_tecnica.Core.Interface.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Backend_prueba_tecnica.Infraestructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<bool> CrearUsuarioAsync(User user)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO Users (
                                Nombre, 
                                Apellido, 
                                TipoDocumento, 
                                FechaNacimiento, 
                                ValorAGanar, 
                                IdEstadoCivil)
                          VALUES (@Nombre, @Apellido, @TipoDocumento, @FechaNacimiento, @ValorAGanar, @IdEstadoCivil)";

                var parameters = new
                {
                    Nombre = user.Nombre,
                    Apellido = user.Apellido,
                    TipoDocumento = user.TipoDocumento,
                    FechaNacimiento = user.FechaNacimiento,
                    ValorAGanar = user.ValorAGanar,
                    IdEstadoCivil = user.IdEstadoCivil,
                };

                await connection.ExecuteAsync(query, parameters);

                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }
}

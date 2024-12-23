using Backend_prueba_tecnica.Core.DTOs;
using Backend_prueba_tecnica.Core.Interface.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Backend_prueba_tecnica.Infraestructure.Repository;

public class EstadoCivilRepository : IEstadoCivilRepository
{
    private readonly string _connectionString;

    public EstadoCivilRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<EstadoCivil>> ObtenerEstadosCivilAsync()
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var usuarios = await connection.QueryAsync<EstadoCivil>("select Nombre from EstadosCivil");
                return usuarios.ToList();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<EstadoCivil>();
        }
    }
}

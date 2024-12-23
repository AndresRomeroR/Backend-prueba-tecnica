namespace Backend_prueba_tecnica.Core.DTOs;

public class User
{
    public string Nombre {  get; set; }
    public string Apellido { get; set; }
    public string TipoDocumento { get; set; }
    public DateTime FechaNacimiento {  get; set; }
    public Decimal ValorAGanar { get; set; }
    public int IdEstadoCivil {  get; set; }
}

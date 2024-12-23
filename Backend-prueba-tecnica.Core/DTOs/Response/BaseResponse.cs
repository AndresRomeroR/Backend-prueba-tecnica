namespace Backend_prueba_tecnica.Core.DTOs.Response;

public class BaseResponse
{
    public string Message { get; set; }
    public string Exception { get; set; }
    public dynamic Data { get; set; }
}

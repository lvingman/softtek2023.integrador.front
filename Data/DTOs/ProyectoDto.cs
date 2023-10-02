namespace Data.DTOs;

public class ProyectoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public int IdEstado { get; set; }
    public string? Estado { get; set; }
}
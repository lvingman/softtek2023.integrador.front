namespace Data.DTOs;

public class TrabajoDto
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int IdProyecto { get; set; }
    public int IdServicio { get; set; }
    public int CantidadHoras { get; set; }
    public double ValorHora { get; set; }
    public double Costo { get; set; }
}
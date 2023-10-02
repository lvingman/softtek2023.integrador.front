using Data.DTOs;

namespace TechOilFront.ViewModels;

public class TrabajoViewModel
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int IdProyecto { get; set; }
    public int IdServicio { get; set; }
    public int CantidadHoras { get; set; }
    public double ValorHora { get; set; }
    public double Costo { get; set; }
    
    public static implicit operator TrabajoViewModel(TrabajoDto trabajo)
    {
        var trabajosViewModel = new TrabajoViewModel();
        trabajosViewModel.Id = trabajo.Id;
        trabajosViewModel.Fecha = trabajo.Fecha;
        trabajosViewModel.IdProyecto = trabajo.IdProyecto;
        trabajosViewModel.IdServicio = trabajo.IdServicio;
        trabajosViewModel.CantidadHoras = trabajo.CantidadHoras;
        trabajosViewModel.ValorHora = trabajo.ValorHora;
        return trabajosViewModel;
    }
    
}
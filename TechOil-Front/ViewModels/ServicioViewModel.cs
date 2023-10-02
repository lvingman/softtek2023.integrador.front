using Data.DTOs;

namespace TechOilFront.ViewModels;

public class ServicioViewModel
{
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public double ValorHora { get; set; }
    
    public bool Estado { get; set; }

    
    public static implicit operator ServicioViewModel(ServicioDto servicio)
    {
        var serviciosViewModel = new ServicioViewModel();
        serviciosViewModel.Id = servicio.Id;
        serviciosViewModel.Descripcion = servicio.Descripcion;
        serviciosViewModel.ValorHora = servicio.ValorHora;
        serviciosViewModel.Estado = servicio.Estado;
        return serviciosViewModel;
    }
}
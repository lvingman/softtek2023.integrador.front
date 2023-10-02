using Data.DTOs;

namespace TechOilFront.ViewModels;

public class ProyectoViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public int IdEstado { get; set; }
    public string? Estado { get; set; }
    
    public static implicit operator ProyectoViewModel(ProyectoDto proyecto)
    {
        var proyectosViewModel = new ProyectoViewModel();
        proyectosViewModel.Id = proyecto.Id;
        proyectosViewModel.Nombre = proyecto.Nombre;
        proyectosViewModel.Direccion = proyecto.Direccion;
        proyectosViewModel.IdEstado = proyecto.IdEstado;
        proyectosViewModel.Estado = proyecto.Estado;
        return proyectosViewModel;
    }
}
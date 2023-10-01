using Data.DTOs;

namespace TechOilFront.ViewModels;

public class UsuarioViewModel
{
    public string Nombre { get; set; }
    public int Dni { get; set; }
    public int IdRol { get; set; }
    public string? Rol { get; set; }
    public string Contrasena { get; set; }
    public string Email { get; set; }

    public static implicit operator UsuarioViewModel(UsuarioDto usuario)
    {
        var usuariosViewModel = new UsuarioViewModel();
        usuariosViewModel.Nombre = usuario.Nombre;
        usuariosViewModel.Dni = usuario.Dni;
        usuariosViewModel.IdRol = usuario.IdRol;
        usuariosViewModel.Contrasena = usuario.Contrasena;
        usuariosViewModel.Email = usuario.Email;
        return usuariosViewModel;
    }
    
}
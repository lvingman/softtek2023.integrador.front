using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    //Hipoteticamente para generar y modificar usuarios
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int IdRol { get; set; }
        public string? Rol { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
    }
}
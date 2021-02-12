using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingDapper.Models
{
    public class tipo_usuarios
    {
        public int IdTipoUsuarios { get; set; }
        public string tipo { get; set; }
        public Boolean eliminado { get; set; }
        public string Message { get; set; }
    }
}

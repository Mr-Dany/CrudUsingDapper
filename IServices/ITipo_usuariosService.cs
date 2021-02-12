using CrudUsingDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingDapper.IServices
{
    public interface ITipo_usuariosService
    {
        tipo_usuarios Save(tipo_usuarios ostipo_usuarios);
        List<tipo_usuarios> Gets();
        tipo_usuarios Get(int IdTipoUsuarios);
        string Delete(int IdTipoUsuarios);
    }
}

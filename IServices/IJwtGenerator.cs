using CrudUsingDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingDapper.IServices
{
    public interface IJwtGenerator
    {

        string creartoken(tipo_usuarios tipo_usuarios)

    }
}

using CrudUsingDapper.IServices;
using CrudUsingDapper.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudUsingDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuariosController : ControllerBase
    {
        private ITipo_usuariosService _oSTipoUsuarioService;
        public TipoUsuariosController(ITipo_usuariosService oSTipoUsuarioService)
        {
            _oSTipoUsuarioService = oSTipoUsuarioService;
        }

        // GET: api/<TipoUsuariosController>
        [HttpGet]
        public IEnumerable<tipo_usuarios> Get()
        {
            return _oSTipoUsuarioService.Gets();
        }


        // GET api/<TipoUsuariosController>/5
        [HttpGet("{id}")]
        public tipo_usuarios Get(int id)
        {
            return _oSTipoUsuarioService.Get(id);
        }

        // POST api/<TipoUsuariosController>
        [HttpPost]
        public tipo_usuarios Post([FromBody] tipo_usuarios oSTipoUsuarioService)
        {

            if (ModelState.IsValid) return _oSTipoUsuarioService.Save(oSTipoUsuarioService);
            return oSTipoUsuarioService;
        }

        // PUT api/<TipoUsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TipoUsuariosController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _oSTipoUsuarioService.Delete(id);
        }
    }
}

using CrudUsingDapper.IServices;
using CrudUsingDapper.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Datatime;


namespace CrudUsingDapper.Seguridad
{
    public class JwtGenerator : IJwtGenerator
    {
        public string creartoken(tipo_usuarios tipo_usuarios)
        {
            var claims = new List<Claim>
           {
               new Claim(JwtRegisteredClaimNames.NameId, tipo_usuarios.tipo)

           };



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreta"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokensDescripcion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = new DateTime.Now ( 3 ),
                SigningCredentials = credenciales,
            };
        }
    }
}

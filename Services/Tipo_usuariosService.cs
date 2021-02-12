using CrudUsingDapper.Common;
using CrudUsingDapper.IServices;
using CrudUsingDapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingDapper.Services
{
    public class Tipo_usuariosService : ITipo_usuariosService
    {



        tipo_usuarios _ostipo_usuario = new tipo_usuarios();
        List<tipo_usuarios> _ostipo_usuarios = new List<tipo_usuarios>();
        public string Delete(int IdTipoUsuarios)
        {
            string message = "";
            try
            {
                _ostipo_usuario = new tipo_usuarios()
                {
                    IdTipoUsuarios = IdTipoUsuarios
                };
                using IDbConnection con = new SqlConnection(Global.ConnectionString);
                if (con.State == ConnectionState.Closed) con.Open();
                var oStipo_usuarios = con.Query<tipo_usuarios>("SP_TipoUsuarios",
                    this.SetParameters(_ostipo_usuario, (int)OperationType.Delete),
                    commandType: CommandType.StoredProcedure);
                if (oStipo_usuarios != null && oStipo_usuarios.Count() > 0)
                {
                    _ostipo_usuario = oStipo_usuarios.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            return message;
        }

        public tipo_usuarios Get(int IdTipoUsuarios)
        {


            _ostipo_usuario = new tipo_usuarios();
            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                var ostipo_usuarios = con.Query<tipo_usuarios>("SELECT *FROM tipo_usuarios WHERE IdTipoUsuarios = " + IdTipoUsuarios).ToList();
                if (ostipo_usuarios != null && ostipo_usuarios.Count() > 0)
                {
                    _ostipo_usuario = ostipo_usuarios.SingleOrDefault();
                }
            }
            return _ostipo_usuario;





        }

        public List<tipo_usuarios> Gets()
        {

            _ostipo_usuarios = new List<tipo_usuarios>();

            using (IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == ConnectionState.Closed) con.Open();
                var ostipo_usuarios = con.Query<tipo_usuarios>("SELECT *FROM tipo_usuarios").ToList();
                if (ostipo_usuarios != null && ostipo_usuarios.Count() > 0)
                {
                    _ostipo_usuarios = ostipo_usuarios;
                }
            }
            return _ostipo_usuarios;
        }

        public tipo_usuarios Save(tipo_usuarios ostipo_usuarios)
        {

            _ostipo_usuario = new tipo_usuarios();
            try
            {
                int operationType = Convert.ToInt32(ostipo_usuarios.IdTipoUsuarios == 0 ? OperationType.Insert : OperationType.Update);
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oStudents = con.Query<tipo_usuarios>("SP_TipoUsuarios",
                        this.SetParameters(ostipo_usuarios, operationType),
                        commandType: CommandType.StoredProcedure);
                    if (oStudents != null && oStudents.Count() > 0)
                    {
                        _ostipo_usuario = oStudents.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {

                _ostipo_usuario.Message = ex.Message;
            }
            return _ostipo_usuario;

        }



        private DynamicParameters SetParameters(tipo_usuarios oStipo_usuarios, int operationType)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@@IdTipoUsuarios", oStipo_usuarios.IdTipoUsuarios);
            parameters.Add("@tipo", oStipo_usuarios.tipo);
            parameters.Add("@eliminado", oStipo_usuarios.eliminado);
            parameters.Add("@OperationType", operationType);
            return parameters;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class User
    {
        public static ML.Result Add(ML.User user)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JuegoInglesEntities context = new DL.JuegoInglesEntities())
                {

                    using (SqlConnection conexion = new SqlConnection(context.Database.Connection.ConnectionString))
                    {
                        conexion.Open();

                        using (SqlCommand comando = conexion.CreateCommand())
                        {
                            comando.CommandType = CommandType.StoredProcedure;
                            comando.CommandText = "UsuarioAdd";

                            comando.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                            comando.Parameters.Add(new SqlParameter("@Nombre", user.Nombre));
                            comando.Parameters.Add(new SqlParameter("@ApellidoPaterno", user.ApellidoPaterno));
                            comando.Parameters.Add(new SqlParameter("@ApellidoMaterno", user.ApellidoMaterno));
                            comando.Parameters.Add(new SqlParameter("@Password", user.Password));

                            int query = comando.ExecuteNonQuery();

                            if (query > 0)
                            {
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                            }
                        }
                        conexion.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetByUserName(string userName)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JuegoInglesEntities context = new DL.JuegoInglesEntities())
                {
                    var query = context.UsuarioGetByUserName(userName).FirstOrDefault();

                    if (query != null)
                    {
                        ML.User user = new ML.User();
                        user.IdUsuario = query.IdUsuario;
                        user.UserName = query.UserName;
                        user.Nombre = query.Nombre;
                        user.ApellidoMaterno = query.ApellidoMaterno;
                        user.ApellidoPaterno = query.ApellidoPaterno;
                        user.Password = query.Password;

                        result.Object = user;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

    }
}

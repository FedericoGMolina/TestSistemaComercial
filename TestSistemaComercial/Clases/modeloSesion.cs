using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace TestSistemaComercial.Clases
{
    class modeloSesion
    {
        private MySqlConnection miConexion = new Conexion().getConexion();
        private string sql = "";
        private MySqlCommand comando;
        private MySqlDataReader reader;
        public Usuario miUsuario(String usuario)
        {
            Usuario user = null;
            miConexion.Open();
            sql = "Select * from usuarios where User Like @user";
            comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@User", usuario);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = new Usuario();
                    user.Id = int.Parse(reader["idUser"].ToString());
                    user.user = reader["User"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.Nombre = reader["Nombre"].ToString();
                    user.IdTipo = int.Parse(reader["idTipoUser"].ToString());
                }
            }
            miConexion.Close();
            return user;
        }
    }
}

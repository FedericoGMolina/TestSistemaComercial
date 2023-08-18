using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace TestSistemaComercial
{
    class modeloSesion
    {
       
        private MySqlConnection miConexion = new Conexion().GetConexion();
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
        public bool UsuarioExiste(string usuario)
        {
            miConexion.Open();
            sql = "SELECT COUNT(*) FROM usuarios WHERE User = @user";
            comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@User", usuario);
            int count = Convert.ToInt32(comando.ExecuteScalar());
            miConexion.Close();

            return count > 0;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            miConexion.Open();
            sql = "INSERT INTO usuarios (User, Password) " +
                  "VALUES (@User, @Password)";
            comando = new MySqlCommand(sql, miConexion);
            comando.Parameters.AddWithValue("@User", usuario.user);
            comando.Parameters.AddWithValue("@Password", usuario.Password);
            try
            {
                int rowsAffected = comando.ExecuteNonQuery();
                miConexion.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message);
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace TestSistemaComercial
{
    class modeloUsuarios
    {
        private MySqlConnection miConexion = new Conexion().GetConexion();
        private string sql;
        public DataTable obtenerUsuarios()
        {
            miConexion.Open();
            sql = "SELECT CONCAT(User, '-', u.Nombre) AS Socio, tp.Nombre AS 'Tipo Usuario' " + "FROM usuarios u " +
                 "INNER JOIN tipousuarios tp ON u.idTipoUser = tp.idTipo";

            MySqlCommand comando = new MySqlCommand(sql, miConexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = comando;
            DataTable tabla = new DataTable();
            tabla.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(tabla);
            miConexion.Close();
            return tabla;
        }
    }
}

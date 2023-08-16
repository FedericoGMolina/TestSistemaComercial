using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TestSistemaComercial
{
    public class Conexion
    {

        private string servidor = "datasource = 127.0.0.1";
        private string puerto = "port = 3306";
        private string username = "username = root";
        private string password = "password = ";
        private string bd = "database = test";

        public MySqlConnection GetConexion()
        {
            string cadenaConexion = servidor + ";" + puerto + ";" +
            username + ";" + password + ";" + bd;
            return new MySqlConnection(cadenaConexion);
        }
    }
}

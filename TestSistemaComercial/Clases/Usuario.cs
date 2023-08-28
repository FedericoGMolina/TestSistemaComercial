using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSistemaComercial
{
    public class Usuario
    {
        private int id;
        private string usuario;
        private string password;
        private string passwordConfirma;
        private string nombre;
        private string documento;
        private int idTipo;

        public int Id { get => id; set => id = value; }
        public string user { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        public string PasswordConfirma
        {
            get => passwordConfirma; set =>
            passwordConfirma = value;
        }
        public string Documento { get => documento; set => documento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
    }
}

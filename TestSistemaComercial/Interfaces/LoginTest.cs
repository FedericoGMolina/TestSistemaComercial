using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace TestSistemaComercial
{
    public partial class LoginTest : Form
    {
        private string servidor = "datasource = 127.0.0.1";
        private string puerto = "port = 3306";
        private string username = "username = root";
        private string password = "password = ";
        private string bd = "database = test";
        public LoginTest()
        {
            InitializeComponent();
        }
        public MySqlConnection getConexion()
        {
            string cadenaConexion = servidor + ";" + puerto + ";" +
            username + ";" + password + ";" + bd;
            return new MySqlConnection(cadenaConexion);
        }
        //Pendiente
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Problema a solucionar
            if (txtUsuarioLogin.Text == "" || txtContraseñaLogin.Text == "")
                MessageBox.Show("Por favor, complete los campos solicitados.");
            //Problema a solucionar
        }
        //Pendiente
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
            register.FormClosing += register_closing;
        }
        private void register_closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
        private void btnCancelarLogin_Click(object sender, EventArgs e)
        {
            txtUsuarioLogin.Text = "";
            txtContraseñaLogin.Text = "";
        }
        private void btnSalirLogin_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Desea cerrar el programa?", "Sistema Comercial (Login)", MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);

            if (resp == DialogResult.OK)
                Application.Exit();
        }

        private void txtUsuarioLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"[^a-zA-Z0-9Ññ\s]");
            if (!char.IsControl(e.KeyChar) && regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            if (e.KeyChar != '\b' && e.KeyChar == ' ' && regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }

            if (!regex.IsMatch(e.KeyChar.ToString()))
            {
                txtUsuarioLogin.Tag = Brushes.Red;
            }
        }
    }
}

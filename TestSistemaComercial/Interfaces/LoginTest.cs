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
       public LoginTest()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuarioLogin.Text == "" || txtContraseñaLogin.Text == "")
                MessageBox.Show("Por favor, complete los campos solicitados.");
            try
            {
                String usuario = txtUsuarioLogin.Text;
                String pass = txtContraseñaLogin.Text;
                controlSesion control = new controlSesion();
                String respuestaControlador = control.ctrlLogin(usuario, pass);
                if (respuestaControlador == "¡Bienvenido!")
                {
                    MessageBox.Show(control.ctrlLogin(usuario, pass), "Control de usuarios",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Principal p = new Principal();
                    this.Visible = false; //Oculta el formulario de inicio de sesión.
                    p.Show();
                }
                else
                {
                    MessageBox.Show(respuestaControlador, "Control de usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtUsuarioLogin.Text == "")
                        txtUsuarioLogin.Focus();
                    else
                        txtContraseñaLogin.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
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
            Regex regex = new Regex(@"\W");
            if (!char.IsControl(e.KeyChar) && regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
                txtUsuarioLogin.BackColor = Color.Red;
            }
            else
                txtUsuarioLogin.BackColor = Color.White;
            if (e.KeyChar != '\b' && e.KeyChar == ' ' && regex.IsMatch(e.KeyChar.ToString()))
                e.Handled = true;
        }
    }
}

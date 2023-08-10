﻿using System;
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

            if (!Regex.Match(txtUsuarioLogin.Text, "[a-zA-Z]").Success)
            {
                MessageBox.Show("(Campo Usuario): Caracteres invalidos ingresados. Asegurese de ingresar un Usuario de la a-z y/o A-Z");
                txtUsuarioLogin.Focus();
            }

            if (!Regex.Match(txtContraseñaLogin.Text, "[a-zA-Z0-9ñÑ]").Success)
            {
                MessageBox.Show("(Campo Contraseña): Caracteres invalidos ingresados. Asegurese de ingresar solo este tipo de caracteres: [a-z_A-Z] y/o [0-9]");
                txtContraseñaLogin.Focus();
            }
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
    }
}

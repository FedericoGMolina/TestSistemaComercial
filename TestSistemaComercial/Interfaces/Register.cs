﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSistemaComercial
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }


        private void btnSalirRegister_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Desea cerrar el programa?", "Sistema Comercial (Register)", MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question);

            if (resp == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelarRegister_Click(object sender, EventArgs e)
        {
            txtContraseñaRegister.Text = "";
            txtDocumentoRegister.Text = "";
            txtUsuarioRegister.Text = "";
        }
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuarioRegister.Text;
            string contraseña = txtContraseñaRegister.Text;
            // Otros campos necesarios para el registro

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Registro",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuario nuevoUsuario = new Usuario();

            controlSesion control = new controlSesion();
            nuevoUsuario.Id = 124;
            nuevoUsuario.user = usuario;
            nuevoUsuario.Password = control.generarSHA1(contraseña);
            nuevoUsuario.PasswordConfirma = control.generarSHA1(contraseña);
            nuevoUsuario.Nombre = usuario;
            nuevoUsuario.IdTipo = 1;

            string respuesta = control.RegistrarUsuario(nuevoUsuario);

            MessageBox.Show(respuesta, "Registro", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            if (respuesta == "¡Usuario registrado correctamente!")
                this.Close();
        }
    }
}

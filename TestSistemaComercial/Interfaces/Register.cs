using System;
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

        }
    }
}

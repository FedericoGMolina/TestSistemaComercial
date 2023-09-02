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
    public partial class Principal : Form
    {
        public Principal(string usuario)
        {
            InitializeComponent();
            labelNombreUsuario.Text = usuario;            
        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            Personal personal = new Personal();
            abrirFormularioHijo(personal);
        }

        private Form activeForm = null;
        private void abrirFormularioHijo(Form formularioHijo)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panel1.Controls.Add(formularioHijo);
            panel1.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }
    }
}

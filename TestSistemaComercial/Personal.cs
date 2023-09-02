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
    public partial class Personal : Form
    {
        public Personal()
        {
            InitializeComponent();
            cargaDataGrid();
        }

        private void cargaDataGrid()
        {
            dataGridView.DataSource = null;
            modeloUsuarios m = new modeloUsuarios();
            dataGridView.DataSource = m.obtenerUsuarios();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

    }
}

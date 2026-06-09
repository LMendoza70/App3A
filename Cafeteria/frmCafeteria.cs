using Calificaciones.Cafeteria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App3A.Cafeteria
{
    public partial class frmCafeteria : Form
    {
        private List<Bebida> bebidas;
        public frmCafeteria()
        {
            InitializeComponent();
            bebidas = new List<Bebida>();
        }

        private void rdbCaliente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCaliente.Checked == true)
            {
                lblExtra.Text = "Temperatura";
            }
            else
            {
                lblExtra.Text = "Hielos";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //recatamos valores
            string nombre = txtNombre.Text.Trim();
            string tamano = cmbTamano.Text.Trim();
            float precio= float.Parse(txtPrecio.Text.Trim());
            int extra=int.Parse(txtExtra.Text.Trim());

            if (rdbCaliente.Checked)
            {
                bebidas.Add(new BebidaCaliente(nombre,tamano,precio,extra));
            }
            else
            {
                bebidas.Add(new BebidaFria(nombre,tamano,precio,extra));
            }

            MessageBox.Show("Bebida agregada Correctamente tienes "+bebidas.Count +" Bebidas registradas");
            Limpiarcomponentes();
        }

        private void Limpiarcomponentes()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtExtra.Clear();
            cmbTamano.SelectedIndex = -1;
        }
    }
}

using App3A.HolaMundo;
using App3A.Cafeteria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App3A
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal(string user, string rol)
        {
            InitializeComponent();
            this.Text = this.Text + " - Usuario : "+user;
            if (rol == "Alumno")
            {
                cafeteriaToolStripMenuItem.Visible=false;   
            }

        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form calculadora = Application.OpenForms["frmCalculadora"];
            CargaFormulario(calculadora);
        }

        private void cafeteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cafeteria = Application.OpenForms["frmCafeteria"];
            CargaFormulario(cafeteria);
           
        }

        private void CargaFormulario(Form formulario)
        { 
            if (formulario != null)
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                else
                    formulario.Activate();
            }
            else
            {
                formulario = new frmCafeteria();
                formulario.MdiParent = this;
                formulario.FormClosed += (sen, eventargs) => formulario.Dispose();
                formulario.Show();
            }
        }
    }
}

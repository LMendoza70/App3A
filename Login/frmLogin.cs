using App3A.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App3A.Login
{
    public partial class frmLogin : Form
    {
        private frmPrincipal principal;
        public frmLogin()
        {
            InitializeComponent();
            DataConeccion coneccion = new DataConeccion();
            MySqlConnection conn = coneccion.GetConeccion();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text.Trim();
            string contra = txtPassword.Text.Trim();

            if(usuario=="luis" && contra == "mendoza")
            {
                this.Hide();
                principal = new frmPrincipal();
                principal.Show();
                
            }
            else
            {
                lblError.Text = "Credenciales incorrectas...";
                lblError.Visible = true;
                txtUser.Clear();
                txtPassword.Clear();
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            lblError.Visible=false;
        }
    }
}

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
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text.Trim();
            string contra = txtPassword.Text.Trim();

            //validamos si los campos estan llenos 
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contra))
            {
                MessageBox.Show("Profavor ingresa el usurio y contraseña...");
            }

            //conectamos con la base de datos 
            DataConeccion coneccion = new DataConeccion();
            MySqlConnection conn = coneccion.GetConeccion();

            //validamos si la coneccion a base de datos fue exitosa 
            if(conn==null)
            {
                MessageBox.Show("Lo siento la aplicacion no tiene acceso a datos...");
                return;
            }

            try
            {
                //creamos la consulta 
                string consulta = "SELECT * FROM tblusuarios WHERE nombreUsuario=@usuario";
                //ejecutamos la consulta
                MySqlCommand cmd = new MySqlCommand(consulta, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                MySqlDataReader reader = cmd.ExecuteReader();

                //verificamos que la consulta trajo resultados 
                if (reader.Read())
                {
                    string pass = reader["PASSWORD"].ToString();
                    string rol = reader["perfil"].ToString();

                    if (contra == pass)
                    {
                        MessageBox.Show("Acceso correcto");
                        conn.Close();
                        this.Hide();
                        frmPrincipal principal = new frmPrincipal(usuario,rol);
                        principal.Show();

                    }
                    else
                    {
                        MessageBox.Show("Las credenciales no coinciden.... ");
                        return;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Las credenciales no coinciden.... ");
                    return;
                }

            }catch (Exception ex)
            {
                MessageBox.Show("Error :"+ex.Message);
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            lblError.Visible=false;
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App3A.Data
{
    internal class DataConeccion
    {
        //Cadena de coneccion a la base de datos, tiene 5 parametros 
        private readonly string Cadena;

        //creamos nuestro constructor 
        public DataConeccion()
        {
            Cadena = "Server=189.240.192.140; Database=bdescuelaterceros; Uid=grupo3a; Pwd=grupo3a; Port=3306";
        }

        //metodo para conectar a la base de datos 
        public MySqlConnection GetConeccion()
        {
            try {
                MySqlConnection con = new MySqlConnection(Cadena);
                con.Open();
                //MessageBox.Show("Coneccion exitosa ...");
                return con;
            }catch(MySqlException ex) {
                //MessageBox.Show("Error al conectar con la base de datos \n"+ ex.Message);
                return null;
            }
        }
    }
}

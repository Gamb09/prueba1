using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace formulariosencillo
{
    class coneccion
    {
        SqlConnection cm;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter dv;
        DataTable dt;
        public coneccion()
        {
            try
            {
                cm = new SqlConnection("Data Source = GAMB; Initial Catalog = coneccion_testGamb; Integrated Security = True");
                cm.Open();
                MessageBox.Show("Conexion exitosa!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO FURULO!"+ex.ToString());
                throw;
            }
         }
        public string insertar(string textDUI,string texNOMBRE,int textEDAD)
        {
            string salida = "insertado";
            try
            {
                cmd = new SqlCommand("insert into Data1 (Nombre,DUI,edad) values('"+texNOMBRE+"','"+textDUI+"','"+textEDAD+"') ",cm);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "no se conecto:" + ex.ToString();
                throw;
            }
            return salida;
        }

        //procedimiento 2
        public int personaregistrada( int textDUI)
        {
            int contador=0;
            try
            {
                cmd = new SqlCommand("select * from [dbo].Data1 where DUI ="+ textDUI +"", cm);
                dr=cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show( "no se consulto a la base" + ex.ToString());
                throw;
            }
            return contador;
         }
        public void cargardatos(DataGridView dgv)
        {
            try
            {
                dv= new SqlDataAdapter("select * from Data1", cm);
                dt = new DataTable();  
                dv.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el data view"+ex.ToString());
                throw;
            }
        }

    }
}

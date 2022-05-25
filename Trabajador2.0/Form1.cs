using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;

namespace Trabajador2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
 
            InitializeComponent();
            mostrar();
        }
        //Dns.GetHostName() Devulve el nombre del servidor

        string conexion = "Data Source=" + Dns.GetHostName() + ";Initial Catalog=Cleiner;Integrated Security=True";

        void Limpiar()
        {
            txtCargoTra.Clear();    
            txtCorreo.Clear();
            txtDireccionTra.Clear();
            txtDni.Clear();
            txtIdtra.Clear();
            txtNombTra.Clear();
            txtTelefonoTra.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
            
        {
            using (SqlConnection cn = new SqlConnection(conexion)) 
            {
                SqlCommand cmd = new SqlCommand("insert into Trabajador(IdTrabajador,dni ,Nom_Trabajador ,Cargo ,Direccion ,Correo ,Telefono) values("+txtIdtra.Text+",'"+txtDni.Text+"','"+txtNombTra.Text+"','"+txtCargoTra.Text+"','"+txtDireccionTra.Text+"','"+txtCorreo.Text+"','"+txtTelefonoTra.Text+"')",cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();

            }
            Limpiar();
            mostrar();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("update Trabajador set dni='" + txtDni.Text + "' ,Nom_Trabajador='" + txtNombTra.Text + "' ,Cargo='" + txtCargoTra.Text + "' ,Direccion='" + txtDireccionTra.Text + "' ,Correo='" + txtCorreo.Text + "' ,Telefono='" + txtTelefonoTra.Text + "'  where IdTrabajador=" + txtIdtra.Text + " ", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            Limpiar();
            mostrar();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("delete from Trabajador where IdTrabajador= " + txtIdtra.Text + "", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            Limpiar();
            mostrar();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(conexion))
            {

                SqlDataAdapter da = new SqlDataAdapter("select *from Trabajador", cn);
                da.SelectCommand.CommandType=CommandType.Text;
                cn.Open();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            Limpiar();
            mostrar();
        }

        void mostrar(){
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(conexion))
            {

                SqlDataAdapter da = new SqlDataAdapter("select *from Trabajador", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                cn.Open();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

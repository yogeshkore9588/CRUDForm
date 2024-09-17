using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-FI1733H9\\SQLEXPRESS;Initial Catalog=CRUDForm;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into ut values(@id, @name, @age)", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sucessfully Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-FI1733H9\\SQLEXPRESS;Initial Catalog=CRUDForm;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("Update ut set name=@name, age=@age",con);
            //cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", textBox3.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sucessfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-FI1733H9\\SQLEXPRESS;Initial Catalog=CRUDForm;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("delete ut where id=@id", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sucessfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-FI1733H9\\SQLEXPRESS;Initial Catalog=CRUDForm;Integrated Security=True;TrustServerCertificate=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from ut where id=@id", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}

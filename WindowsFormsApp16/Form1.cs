using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {

        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            con = new OracleConnection(ordb);
            con.Open();
            */
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = con;
            c.CommandText = "select fname, lname from insurancee where SSN=:Id";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("Id", textBox1.Text);
            OracleDataReader dr = c.ExecuteReader();

            if (dr.Read())
            {
                textBox2.Text = dr[0].ToString();
                textBox3.Text = dr[1].ToString();

            }

           

            dr.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();

        }
    }
}

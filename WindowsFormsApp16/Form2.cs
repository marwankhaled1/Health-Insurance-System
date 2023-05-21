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
    public partial class Form2 : Form
    {
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            con = new OracleConnection(ordb);
            con.Open();
        }

        private void label5_Click(object sender, EventArgs e)
        {




        }

        private void button2_Click(object sender, EventArgs e)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Bank values( :id ,:name, :Location,:phone,:Email)";

            cmd.Parameters.Add("id", int.Parse(textBox2.Text));
            cmd.Parameters.Add("name", textBox1.Text);
            cmd.Parameters.Add("Location", textBox3.Text);
            cmd.Parameters.Add("phone", int.Parse(textBox5.Text));
            cmd.Parameters.Add("Email", textBox4.Text);
            int r = cmd.ExecuteNonQuery();

            if (r != -1)
            {
                MessageBox.Show("Bank Added successfully");

            }


        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

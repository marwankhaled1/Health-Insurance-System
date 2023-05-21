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
    public partial class Form3 : Form
    {
        OracleConnection con;
        string ordb = "data source = orcl; user id =scott; password=tiger;";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {


            con = new OracleConnection(ordb);
            con.Open();



        }

        private void button1_Click(object sender, EventArgs e)
        {


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(":policy_num",int.Parse(textBox1.Text));
            cmd.Parameters.Add(":cursor", OracleDbType.RefCursor,ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();

            }
            dr.Close();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

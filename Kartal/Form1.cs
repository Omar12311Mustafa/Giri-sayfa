using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kartal
{
    public partial class Form1 : Form
    {

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string usr = textBox1.Text;
            string psw = textBox2.Text;
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C://kisi.mdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM tblUser where @ad='" + textBox1.Text + "' AND @parola='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect");
            }

            con.Close();    
        }
    }
}

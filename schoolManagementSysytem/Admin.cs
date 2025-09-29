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
using System.Data.SqlClient;

namespace schoolManagementSysytem
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

       

        private void Admin_Load(object sender, EventArgs e)
        {
            display();
            display4();
            display6();
            display8();

        }

        private void display()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT COUNT(*) FROM student ", con);
            Int32 count = Convert.ToInt32(cnn.ExecuteScalar());
            if (count > 0)
            {
                label3.Text = Convert.ToString(count.ToString());
            }
            else
            {
                label3.Text = "0";
            }
            con.Close();
        }

        private void display8()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT COUNT(*) FROM enroll ", con);
            Int32 count = Convert.ToInt32(cnn.ExecuteScalar());
            if (count > 0)
            {
                label8.Text = Convert.ToString(count.ToString());
            }
            else
            {
                label8.Text = "0";
            }
            con.Close();
        }

        private void display6()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT COUNT(*) FROM teacher ", con);
            Int32 count = Convert.ToInt32(cnn.ExecuteScalar());
            if (count > 0)
            {
                label6.Text = Convert.ToString(count.ToString());
            }
            else
            {
                label6.Text = "0";
            }
            con.Close();
        }

        private void display4()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("SELECT COUNT(*) FROM subject ", con);
            Int32 count = Convert.ToInt32(cnn.ExecuteScalar());
            if (count > 0)
            {
                label4.Text = Convert.ToString(count.ToString());
            }
            else
            {
                label4.Text = "0";
            }
            con.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

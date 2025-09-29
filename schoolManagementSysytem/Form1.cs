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

namespace schoolManagementSysytem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True");
            try
            {
                con.Open();
                string username = textUserName.Text;
                string password = textPassword.Text;

                // Use parameterized query to avoid SQL injection
                SqlCommand cmd = new SqlCommand("select username, password from login where username=@username and password=@password", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataAdapter da = new SqlDataAdapter(cmd); // Corrected variable name
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    main mn = new main();
                    mn.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



    }
}

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
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    // Use parameterized query to avoid SQL injection
                    SqlCommand cnn = new SqlCommand("insert into attendance values(@AId,@StudentName,@Status)", con);
                    cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text)); // studentId as integer
                    cnn.Parameters.AddWithValue("@StudentName", textBox2.Text); // StudentName as string
                    cnn.Parameters.AddWithValue("@Status", textBox3.Text); // StudentName as string

                    cnn.ExecuteNonQuery();
                    MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Input string was not in a correct format. Please check your inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("select * from attendance", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    // Use parameterized query to avoid SQL injection
                    SqlCommand cnn = new SqlCommand("update attendance set StudentName=@StudentName,Status=@Status where AId=@AId", con);
                    cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text)); // studentId as integer
                    cnn.Parameters.AddWithValue("@StudentName", textBox2.Text); // StudentName as string
                    cnn.Parameters.AddWithValue("@Status", textBox3.Text); // StudentName as string

                    cnn.ExecuteNonQuery();
                    MessageBox.Show("Record Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Input string was not in a correct format. Please check your inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    // Use parameterized query to avoid SQL injection
                    SqlCommand cnn = new SqlCommand("delete attendance where AId=@AId", con);
                    cnn.Parameters.AddWithValue("@AId", int.Parse(textBox1.Text)); // studentId as integer


                    cnn.ExecuteNonQuery();
                    MessageBox.Show("Record Delete Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Input string was not in a correct format. Please check your inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("select * from attendance", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

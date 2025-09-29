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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace schoolManagementSysytem
{
    public partial class teacher : Form
    {
        public teacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True"))
                {
                    con.Open();

                    // Use parameterized query to avoid SQL injection
                    SqlCommand cnn = new SqlCommand("insert into teacher values(@TeacherId, @TeacherName, @Gender, @Phone)", con);
                    cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text)); // studentId as integer
                    cnn.Parameters.AddWithValue("@TeacherName", textBox2.Text); // StudentName as string
                    cnn.Parameters.AddWithValue("@Gender", textBox3.Text); // Gender as string
                    cnn.Parameters.AddWithValue("@Phone",textBox4.Text); // Phone as string
                    

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

            SqlCommand cnn = new SqlCommand("select * from teacher", con);
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
                    SqlCommand cnn = new SqlCommand("update teacher set TeacherName=@TeacherName,Gender=@Gender,Phone=@Phone where TeacherId=@TeacherId", con);
                    cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text)); // studentId as integer
                    cnn.Parameters.AddWithValue("@TeacherName", textBox2.Text); // StudentName as string
                    cnn.Parameters.AddWithValue("@Gender", textBox3.Text); // Gender as string
                    cnn.Parameters.AddWithValue("@Phone", textBox4.Text); // Phone as string

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
                    SqlCommand cnn = new SqlCommand("delete teacher where TeacherId=@TeacherId", con);
                    cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text)); // studentId as integer


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
            textBox4.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("select * from teacher", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;

        }
    }
}

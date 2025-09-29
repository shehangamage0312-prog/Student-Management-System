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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {

                dateTimePicker1.CustomFormat = "";

            }

        }

        private void button1_Click(object sender, EventArgs e)
{
    try
    {
        using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True"))
        {
            con.Open();

            // Use parameterized query to avoid SQL injection
            SqlCommand cnn = new SqlCommand("insert into student values(@studentId, @StudentName, @DateOfBirth, @Gender, @Phone, @Email)", con);
            cnn.Parameters.AddWithValue("@studentId", int.Parse(textBox1.Text)); // studentId as integer
            cnn.Parameters.AddWithValue("@StudentName", textBox2.Text); // StudentName as string
            cnn.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value); // DateOfBirth as DateTime
            cnn.Parameters.AddWithValue("@Gender", textBox4.Text); // Gender as string
            cnn.Parameters.AddWithValue("@Phone", textBox5.Text); // Phone as string
            cnn.Parameters.AddWithValue("@Email", textBox6.Text); // Email as string

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

            SqlCommand cnn= new SqlCommand("select * from student",con);
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
                    SqlCommand cnn = new SqlCommand("update student set StudentName=@StudentName, DateOfBirth=@DateOfBirth, Gender=@Gender, Phone=@Phone, Email=@Email where studentId=@studentId", con);
                    cnn.Parameters.AddWithValue("@studentId", int.Parse(textBox1.Text)); // studentId as integer
                    cnn.Parameters.AddWithValue("@StudentName", textBox2.Text); // StudentName as string
                    cnn.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value); // DateOfBirth as DateTime
                    cnn.Parameters.AddWithValue("@Gender", textBox4.Text); // Gender as string
                    cnn.Parameters.AddWithValue("@Phone", textBox5.Text); // Phone as string
                    cnn.Parameters.AddWithValue("@Email", textBox6.Text); // Email as string

                    cnn.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True");

            con.Open();


            // Use parameterized query to avoid SQL injection
            SqlCommand cnn = new SqlCommand("delete student where studentId=@StudentId", con);
            cnn.Parameters.AddWithValue("@studentId", int.Parse(textBox1.Text));
            
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Delete  Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3OUQQJJ\SQLEXPRESS;Initial Catalog=schooldb;Integrated Security=True;TrustServerCertificate=True");

            con.Open();

            SqlCommand cnn = new SqlCommand("select * from student", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;

        }
    }
}

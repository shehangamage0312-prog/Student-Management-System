using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace schoolManagementSysytem
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            subject sub = new subject();
            sub.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            teacher sub = new teacher();
            sub.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Section section = new Section();    
            section.Show(); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          Attendance attendance = new Attendance();
            attendance.Show();
           
         }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();  
            admin.Show();
        }
    }
}

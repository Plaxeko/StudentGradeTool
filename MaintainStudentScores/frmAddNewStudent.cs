using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintainStudentScores
{

    public partial class frmAddNewStudent : Form
    {
        Dictionary<string, List<int>> newStudent = new Dictionary<string, List<int>>();
        List<int> grades = new List<int>();

        public frmAddNewStudent()
        {
            InitializeComponent();
        }

        private void frmAddNewStudent_Activated(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(txtScore.Text) >= 0 && Int32.Parse(txtScore.Text) <= 100)
                {
                    grades.Add(Int32.Parse(txtScore.Text));
                }
                else
                {
                    MessageBox.Show("Please enter a score between 0 and 100!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number");
            }
            txtTotalNew.Text = String.Join(", ", grades);
            txtScore.Text = "";
            txtScore.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grades.Clear();
            txtTotalNew.Text = "";
            txtScore.Text = "";
            txtScore.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                frmStudentScore.students.Add(txtName.Text, grades);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a name", "Empty name field");
                txtName.Focus();
            }
        }
    }
}

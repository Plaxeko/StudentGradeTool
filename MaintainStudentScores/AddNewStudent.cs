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
        List<int> scores = new List<int>();

        public frmAddNewStudent()
        {
            InitializeComponent();
        }

        private void frmAddNewStudent_Activated(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(txtScore.Text) >= 0 && Int32.Parse(txtScore.Text) <= 100)
                {
                    scores.Add(Int32.Parse(txtScore.Text));
                }
                else
                {
                    MessageBox.Show("Please enter a score between 0 and 100.", "Invalid score");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number", "Invalid Entry");
            }
            txtScores.Text = String.Join(", ", scores);
            txtScore.Text = "";
            txtScore.Focus();
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            scores.Clear();
            txtScores.Text = "";
            txtScore.Text = "";
            txtScore.Focus();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                frmStudentScores.students.Add(txtName.Text, scores);
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

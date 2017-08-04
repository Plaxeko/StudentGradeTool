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
    public partial class frmAddScore : Form
    {
        public frmAddScore()
        {
            InitializeComponent();
        }

        private void frmAddScore_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(txtScore.Text) >= 0 && Int32.Parse(txtScore.Text) <= 100)
                {
                    frmUpdateStudentScores.chgStudents.Values.ElementAt(frmStudentScore.selected).Add(Int32.Parse(txtScore.Text));
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a score between 0 and 100!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

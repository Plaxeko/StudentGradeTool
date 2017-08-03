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
    public partial class frmUpdateStudentScores : Form
    {
        public frmUpdateStudentScores()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddScore addScore = new frmAddScore();
            addScore.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpdateScore updateScore = new frmUpdateScore();
            updateScore.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

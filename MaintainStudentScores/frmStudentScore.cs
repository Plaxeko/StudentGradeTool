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
    public partial class frmStudentScore : Form
    {
        public frmStudentScore()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addNewStudent = new frmAddNewStudent();
            addNewStudent.ShowDialog();
            //lbxStudents.Items.Clear();
            //AddToListbox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpdateStudentScores updateStudent = new frmUpdateStudentScores();
            updateStudent.ShowDialog();

        }
    }
}

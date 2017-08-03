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
        public static Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();
        public static int select;

        public frmStudentScore()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addNewStudent = new frmAddNewStudent();
            addNewStudent.ShowDialog();
            lbxStudents.Items.Clear();
            //AddToListbox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpdateStudentScores updateStudent = new frmUpdateStudentScores();
            updateStudent.ShowDialog();

        }

        private void frmStudentScore_Load(object sender, EventArgs e)
        {
            students.Add("Todd Howard", new List<int> { 85, 92, 89, 88});
            students.Add("John Carmack", new List<int> { 92, 100, 87, 72 });

            AddToListBox();
        }

        public void AddToListBox()
        {
            foreach (KeyValuePair<string, List<int>> student in students )
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(student.Key.ToString());
                sb.Append(": (");

                for(int i = 0; i < student.Value.Count; i++)
                {
                    sb.Append( student.Value[i]);
                    if(i != student.Value.Count - 1)
                    sb.Append(", ");
                }

                lbxStudents.Items.Add(sb + ")");
                //lbxStudents.SetSelected(0, true);
                //UpdateInfo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

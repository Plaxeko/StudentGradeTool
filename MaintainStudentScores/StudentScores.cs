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
    public partial class frmStudentScores : Form
    {
        public static Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();
        public static int selected;

        public frmStudentScores()
        {
            InitializeComponent();
        }

        private void frmStudentScores_Load(object sender, EventArgs e)
        {
            students.Add("Todd Howard", new List<int> { 85, 92, 89, 88 });
            students.Add("John Carmack", new List<int> { 92, 100, 87, 72 });

            AddBox();

            // TODO select first in listbox on load
        }

        private void AddBox()
        {
            foreach (KeyValuePair<string, List<int>> student in students)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(student.Key.ToString());
                sb.Append(" - ");
                for (int i = 0; i < student.Value.Count; i++)
                {
                    sb.Append(student.Value[i]);
                    if (i != student.Value.Count - 1)
                    {
                        sb.Append(", ");
                    }
                }
                lbxStudents.Items.Add(sb);
                lbxStudents.SetSelected(0, true);
                UpdateInfo();
            }
        }

        private void UpdateInfo()
        {
            try
            {

                txtScoreTotal.Text = students.Values.ElementAt(lbxStudents.SelectedIndex).Sum().ToString();
                txtScoreCount.Text = students.Values.ElementAt(lbxStudents.SelectedIndex).Count.ToString();
                txtAverage.Text = Math.Round(students.Values.ElementAt(lbxStudents.SelectedIndex).Average()).ToString();
            }
            catch (Exception)
            {
                txtScoreTotal.Text = "";
                txtScoreCount.Text = "";
                txtAverage.Text = "";
            }
        }

        private void lbxStudents_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form addNewStudent = new frmAddNewStudent();
            addNewStudent.ShowDialog();
            lbxStudents.Items.Clear();
            AddBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            students.Remove(students.Keys.ElementAt(lbxStudents.SelectedIndex));
            lbxStudents.Items.Clear();
            AddBox();
            if (students.Count == 0)
            {
                txtScoreTotal.Text = "";
                txtScoreCount.Text = "";
                txtAverage.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form updateScores = new frmUpdateStudentScores();
            selected = lbxStudents.SelectedIndex;
            if (lbxStudents.Items.Count > 0)
            {
                updateScores.ShowDialog(); 
            }
            lbxStudents.Items.Clear();
            AddBox();
        }

        private void frmStudentScores_Activated(object sender, EventArgs e)
        {
            UpdateInfo();
        }
    }
}

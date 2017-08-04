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
        public static  Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();
        public static int selected;

        public frmStudentScore()
        {
            InitializeComponent();
        }

       

        private void frmStudentScore_Load(object sender, EventArgs e)
        {
            students.Add("Todd Howard", new List<int> { 85, 92, 89, 88 });
            students.Add("John Carmack", new List<int> { 92, 100, 87, 72 });

            AddInListBox();
        }

        public void AddInListBox()
        {
            foreach (/*KeyValuePair<string, List<int>>*/var student in students)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(student.Key.ToString());
                sb.Append(": ");

                for (int i = 0; i < student.Value.Count; i++)
                {
                    sb.Append(student.Value[i]);
                    if (i != student.Value.Count - 1)
                        sb.Append(", ");
                }

                lbxStudents.Items.Add(sb);
                lbxStudents.SetSelected(0, true);
                DisplayStats();

            }
        }

        public void DisplayStats()
        {
            try
            {

                txtTotal.Text = students.Values.ElementAt(lbxStudents.SelectedIndex).Sum().ToString();
                txtCount.Text = students.Values.ElementAt(lbxStudents.SelectedIndex).Count.ToString();
                txtAvg.Text = Math.Round(students.Values.ElementAt(lbxStudents.SelectedIndex).Average()).ToString();
                //throw new ErrorStudent("Please enter grades for the new student");
            }
            catch (Exception)
            {
                txtTotal.Text = " ";
                txtCount.Text = " ";
                txtAvg.Text = " ";

            }
        }

        private void lbxStudents_Click(object sender, EventArgs e)
        {
            DisplayStats();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addNewStudent = new frmAddNewStudent();
            addNewStudent.ShowDialog();
            lbxStudents.Items.Clear();
            AddInListBox();
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
            AddInListBox();

        }                    
         

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            students.Remove(students.Keys.ElementAt(lbxStudents.SelectedIndex));
            lbxStudents.Items.Clear();
            AddInListBox();

            if (students.Count == 0)
            {
                txtTotal.Text = "";
                txtCount.Text = "";
                txtAvg.Text = "";
            }
        }

        private void frmStudentScore_Activated(object sender, EventArgs e)
        {
            DisplayStats();
        }
    }
}

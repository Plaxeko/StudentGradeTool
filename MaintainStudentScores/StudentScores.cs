using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            //students.Add("Todd Howard", new List<int> { 85, 92, 89, 88 });
            //students.Add("John Carmack", new List<int> { 92, 100, 87, 72 });
            //students.Add("Hiro Protagonist", new List<int> { 77, 90, 87, 22 });
            AddBox();
            PopulateList(); 

            
          
        }

        private void PopulateList()
        {
            System.IO.Directory.CreateDirectory("C:\\C#.NET\\Files"); //Create directory if it doesnt exist.
            const string sPath = "C:\\C#.NET\\Files\\StudentScores.txt"; //takes care of creating StudentScores.txt




            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            foreach (var item in lbxStudents.Items)
            {
                // AddBox();
                SaveFile.WriteLine(item);

            }
            SaveFile.Close();
        }



        private void AddBox()
        {
            foreach (KeyValuePair<string, List<int>> student in students)
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(student.Key.ToString());
                sb.Append(": (");

                for (int i = 0; i < student.Value.Count; i++)
                {
                    sb.Append(student.Value[i]);
                    if (i != student.Value.Count - 1)
                    {
                        sb.Append(", ");
                    }
                }

                lbxStudents.Items.Add(sb + ")");
                //lbxStudents.SetSelected(0, true);
                PopulateList();
                UpdateInfo();
                
            }
        }

        private void UpdateInfo()
        {
            try
            {

                txtTotal.Text = students.Values.ElementAt(lbxStudents.SelectedIndex).Sum().ToString();
                txtCount.Text = students.Values.ElementAt(lbxStudents.SelectedIndex).Count.ToString();
                txtAvg.Text = Math.Round(students.Values.ElementAt(lbxStudents.SelectedIndex).Average()).ToString();
            }
            catch (Exception)
            {
                txtTotal.Text = "";
                txtCount.Text = "";
                txtAvg.Text = "";
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
                txtTotal.Text = "";
                txtCount.Text = "";
                txtAvg.Text = "";
            }
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStudentScores_Activated(object sender, EventArgs e)
        {
            UpdateInfo();
        }
    }
}

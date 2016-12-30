using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace GlobalizationPointsOfInterest
{
    public partial class ProjectListForm : Form
    {
        private ArrayList projectList;
        private bool[] selectedProjects;

        public ProjectListForm(string solutionName, ArrayList projects, bool[] selected)
        {
            InitializeComponent();

            projectList = projects;
            lblSolution.Text = solutionName;

            selectedProjects = selected;

            treeView1.CheckBoxes = true;
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add("All Projects (" + projectList.Count + ")");

            foreach (string p in projectList)
            {
                var sp1 = p.Split('\\');
                string projectName = sp1[sp1.Length - 1];

                var sp2 = projectName.Split('.');
                treeView1.Nodes.Add(projectName.Substring(0,
                    projectName.Length - sp2[sp2.Length - 1].Length - 1));
            }

            for (int i = 0; i < selected.Count(); ++i)
            {
                treeView1.Nodes[i].Checked = selected[i];
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (projectList != null)
            {
                UpdateProjectList(e);
            }
        }

        private void UpdateProjectList(TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Index == 0)
                {
                    if (e.Node.Checked)
                    {
                        for (int i = 0; i < projectList.Count; ++i) //(var proj in projectList)
                        {
                            selectedProjects[i] = true;
                        }
                    }

                    for (int i = 0; i < treeView1.Nodes.Count; ++i)
                    {
                        treeView1.Nodes[i].Checked = e.Node.Checked;
                        selectedProjects[i] = e.Node.Checked;
                    }
                }
                else
                {
                    selectedProjects[e.Node.Index] = e.Node.Checked;

                    int selectedCount = 0;
                    for (int i = 1; i < selectedProjects.Count(); ++i)
                    {
                        if (selectedProjects[i])
                            ++selectedCount;
                    }

                    treeView1.Nodes[0].Checked = (selectedCount == selectedProjects.Count() - 1) ? true : false;
                    selectedProjects[0] = treeView1.Nodes[0].Checked;
                }
            }
        }
    }
}

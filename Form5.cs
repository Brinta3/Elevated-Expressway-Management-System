using System;
using System.Data;
using System.Windows.Forms;

namespace ELEMS
{
    public partial class Form5 : Form
    {
        private Patrol patrol = new Patrol();

        public Form5()
        {
            InitializeComponent();
            LoadPatrolData();
        }

        // Loads report table
        private void LoadPatrolData()
        {
            DataTable dt = patrol.GetAllReportsWithPatrols();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
            dataGridView1.Columns["ReportId"].ReadOnly = true;
            dataGridView1.Columns["VehicleType"].ReadOnly = true;
            dataGridView1.Columns["Offence"].ReadOnly = true;
            dataGridView1.Columns["Location"].ReadOnly = true;

            
            if (dataGridView1.Columns["PatrolId"] != null)
                dataGridView1.Columns["PatrolId"].ReadOnly = false;
            if (dataGridView1.Columns["PatrolNotes"] != null)
                dataGridView1.Columns["PatrolNotes"].ReadOnly = false;
        }

        // Insert button
        private void button6_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int reportId))
            {
                MessageBox.Show("Enter valid Report ID");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Enter patrol log");
                return;
            }

            patrol.ReportId = reportId;
            patrol.PatrolNotes = textBox2.Text;

            DataTable dt = patrol.GetPatrolByReportId(reportId);
            if (dt.Rows.Count > 0) 
            {
                patrol.PatrolId = Convert.ToInt32(dt.Rows[0]["PatrolId"]);
                patrol.Update();
                MessageBox.Show("Patrol log updated");
            }
            else 
            {
                patrol.Insert();
                MessageBox.Show("Patrol log inserted");
            }

            LoadPatrolData();
        }

        // Delete button
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to delete");
                return;
            }

            var cell = dataGridView1.SelectedRows[0].Cells["PatrolId"].Value;
            if (cell == DBNull.Value)
            {
                MessageBox.Show("No patrol log to delete for this report.");
                return;
            }

            patrol.PatrolId = Convert.ToInt32(cell);
            patrol.Delete();

            MessageBox.Show("Patrol log deleted");
            LoadPatrolData();
        }

        // Clear button
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); 
            textBox2.Clear();
        }

        // Logout button
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        // Update button
        private void button3_Click(object sender, EventArgs e)
        {
  
            dataGridView1.EndEdit();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                
                if (row.Cells["ReportId"].Value == DBNull.Value) continue;
                int reportId = Convert.ToInt32(row.Cells["ReportId"].Value);

                string patrolNotes = row.Cells["PatrolNotes"].Value?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(patrolNotes)) continue;

                DataTable dt = patrol.GetPatrolByReportId(reportId);
                if (dt.Rows.Count > 0)
                {
                    int patrolId = Convert.ToInt32(dt.Rows[0]["PatrolId"]);
                    patrol.PatrolId = patrolId;
                    patrol.PatrolNotes = patrolNotes;
                    patrol.Update();
                }
                else
                {
                    patrol.ReportId = reportId;
                    patrol.PatrolNotes = patrolNotes;
                    patrol.Insert();
                }
            }

            MessageBox.Show("All patrol logs updated successfully.");
            LoadPatrolData();
        }

    }
}

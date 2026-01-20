using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ELEMS
{
    public partial class Form2 : Form
    {
        Database db = new Database();

        public Form2()
        {
            InitializeComponent();
            LoadUsers();
        }

        //Login button
        private void LoadUsers()
        {
            string query = "SELECT * FROM Users";
            dataGridView1.DataSource = db.GetData(query);
        }

        // Log out button
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        // Clear button
        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Clear(); 
            textBox3.Clear(); 
            textBox4.Clear(); 
        }

        // Insert button
        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            string query = "INSERT INTO Users (Role, Username, Password) VALUES (@role, @username, @password)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@role", textBox2.Text),
                new SqlParameter("@username", textBox3.Text),
                new SqlParameter("@password", textBox4.Text)
            };

            db.ExecuteQuery(query, parameters);

            MessageBox.Show("User inserted successfully with auto-generated LoginId!");

            button4_Click(sender, e); 
            LoadUsers(); 
        }

        // Refresh button
        private void button6_Click(object sender, EventArgs e)
        {
            LoadUsers();
            MessageBox.Show("Data refreshed!");
        }

        // Update button
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to update!");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["LoginId"].Value);

            string query = "UPDATE Users SET Role=@role, Username=@username, Password=@password WHERE LoginId=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@role", textBox2.Text),
                new SqlParameter("@username", textBox3.Text),
                new SqlParameter("@password", textBox4.Text),
                new SqlParameter("@id", id)
            };

            db.ExecuteQuery(query, parameters);

            MessageBox.Show("User updated!");
            LoadUsers();
        }

        // Delete button
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to delete!");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["LoginId"].Value);

            string query = "DELETE FROM Users WHERE LoginId=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@id", id)
            };

            db.ExecuteQuery(query, parameters);

            MessageBox.Show("User deleted!");
            LoadUsers();
        }

        //Find button
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text.Trim();
            string role = textBox2.Text.Trim();

            string query = "SELECT * FROM Users WHERE 1=1"; // return all columns

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(username))
            {
                query += " AND Username LIKE @username";
                parameters.Add(new SqlParameter("@username", "%" + username + "%"));
            }

            if (!string.IsNullOrEmpty(role))
            {
                query += " AND Role LIKE @role";
                parameters.Add(new SqlParameter("@role", "%" + role + "%"));
            }

            DataTable dt = db.GetData(query, parameters.ToArray());

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt; 
                dataGridView1.Refresh();       
                MessageBox.Show($"{dt.Rows.Count} record(s) found.");
            }
            else
            {
                dataGridView1.DataSource = null;
                MessageBox.Show("No records found!");
            }
        }

    }
}


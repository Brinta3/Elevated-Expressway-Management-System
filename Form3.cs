using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ELEMS
{
    public partial class Form3 : Form
    {
        Database db = new Database();

        public Form3()
        {
            InitializeComponent();
            textBox3.ReadOnly = true; 
            textBox4.ReadOnly = true;

            LoadVehicles();
        }

        private void LoadVehicles()
        {
            string query = "SELECT * FROM Vehicles";
            DataTable dt = db.GetData(query);
            dataGridView1.DataSource = dt;
        }

        // Entry Button for Adds Entry Time
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToString("g");
        }

        // Calculate Button for Calculates toll
        private void button1_Click(object sender, EventArgs e)
        {
            string type = textBox2.Text.Trim().ToLower();
            Vehicle v;

            if (type == "car") v = new Car { VehicleId = textBox1.Text };
            else if (type == "truck") v = new Truck { VehicleId = textBox1.Text };
            else if (type == "bus") v = new Bus { VehicleId = textBox1.Text };
            else if (type == "bike") v = new Bike { VehicleId = textBox1.Text };
            else
            {
                MessageBox.Show("Invalid Vehicle Type");
                return;
            }

            v.EntryTime = DateTime.Now;
            v.TollStatus = true;

            decimal toll = v.CalculateToll();
            textBox4.Text = toll.ToString();
        }

        // Log Out Button
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        // Report Button
        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        // Clear Button
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        // Insert Button for Save to DB
        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            string query =
                "INSERT INTO Vehicles (VehicleId, VehicleType, EntryTime, TollAmount) " +
                "VALUES ('" + textBox1.Text + "','" +
                             textBox2.Text + "','" +
                             textBox3.Text + "'," +
                             textBox4.Text + ")";

            db.ExecuteQuery(query);

            MessageBox.Show("Vehicle data saved!");

            button5_Click(sender, e);
            LoadVehicles();           
        }

        //refresh button
        private void button7_Click(object sender, EventArgs e)
        {
            LoadVehicles();
            MessageBox.Show("Database refreshed!");
        }

        // log out button
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

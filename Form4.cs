using System;
using System.Windows.Forms;

namespace ELEMS
{
    public partial class Form4 : Form
    {
        Database db = new Database();

        public Form4()
        {
            InitializeComponent();
            
         
        }

        // Refresh button
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        // Back button
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        // Report button
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            string query = "INSERT INTO Reports (VehicleType, Offence, Location) VALUES (@VehicleType, @Offence, @Location)";
            var parameters = new[]
            {
                new Microsoft.Data.SqlClient.SqlParameter("@VehicleType", textBox1.Text),
                new Microsoft.Data.SqlClient.SqlParameter("@Offence", textBox2.Text),
                new Microsoft.Data.SqlClient.SqlParameter("@Location", textBox3.Text)
            };
            db.ExecuteQuery(query, parameters);

            MessageBox.Show("Report saved successfully");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}

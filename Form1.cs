using System;
using System.Windows.Forms;

namespace ELEMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*'; // Starring password brinta
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password!");
                return;
            }
            //user
            var (success, role) = Login.ValidateUser(username, password);

            if (success)
            {
                MessageBox.Show($"Welcome {role}!");

                // login based on role brinta
                switch (role.ToLower())
                {
                    case "admin":
                        Form2 f2 = new Form2();
                        f2.Show();
                        this.Hide();
                        break;

                    case "toll":
                        Form3 f3 = new Form3();
                        f3.Show();
                        this.Hide();
                        break;

                    case "patrol":
                        Form5 f5 = new Form5();
                        f5.Show();
                        this.Hide();
                        break;

                    default:
                        MessageBox.Show("Role not recognized!");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }
    }
}

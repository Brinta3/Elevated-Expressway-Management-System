using System;
using System.Data;

namespace ELEMS
{
    public class Login
    {
        // basic users
        private static readonly (string username, string password, string role)[] defaultUsers =
        {
            ("admin", "1234", "Admin"),
            ("toll", "1234", "Toll"),
            ("patrol", "1234", "Patrol")
        };

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Login(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        // user login
        public static (bool success, string role) ValidateUser(string username, string password)
        {
           
            foreach (var user in defaultUsers)
            {
                if (username == user.username && password == user.password)
                    return (true, user.role);
            }

            // database users
            try
            {
                Database db = new Database();

                string query = $"SELECT Role FROM Users WHERE LoginId='{username}' AND Password='{password}'";
                DataTable dt = db.GetData(query);

                if (dt.Rows.Count == 1)
                {
                    string role = dt.Rows[0]["Role"].ToString();
                    return (true, role);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Database error: " + ex.Message);
            }

            return (false, "");
        }
    }
}

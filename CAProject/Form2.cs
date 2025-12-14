using CAProject.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DatabaseHotel.Initialize();

            //For demonstration purposes, add a default user if none exist
            //using (var conn = new SQLiteConnection("Data Source=reservationsystem.db"))
            //{
            //    conn.Open();
            //    var cmd = conn.CreateCommand();
            //    cmd.CommandText = "INSERT INTO Users (Username, Password) VALUES ('admin', 'password')";
            //    cmd.ExecuteNonQuery();
            //}
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            bool isValid = DatabaseHotel.ValidateUser(username, password);

            if (isValid)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                new Form1().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
        }
    }
}

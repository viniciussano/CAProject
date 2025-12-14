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
        }

        // Login button event handler
        private void loginButton_Click(object sender, EventArgs e)
        {
            // Retrieve username and password from text boxes
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Validate user credentials
            bool isValid = DatabaseHotel.ValidateUser(username, password);

            // Show appropriate message based on validation result
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

        // Show Password checkbox event handler
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            passwordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
        }

        // Exit button event handler
        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }
    }
}

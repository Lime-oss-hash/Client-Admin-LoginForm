using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        // Hardcoded admin credentials
        private const string AdminUsername = "admin";
        private const string AdminPassword = "admin123";

        // Hardcoded client credentials
        private const string ClientUsername = "client";
        private const string ClientPassword = "client123";

        // Dictionary to store registered clients
        private Dictionary<string, string> clients = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Client");
            comboBox1.Items.Add("Admin");
            comboBox1.SelectedIndex = 0;

            // Add the default client credentials to the clients dictionary
            clients.Add(ClientUsername, ClientPassword);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string selectedRole = comboBox1.SelectedItem.ToString();

            if (selectedRole == "Admin")
            {
                if (username == AdminUsername && password == AdminPassword)
                {
                    MessageBox.Show("Admin logged in successfully!");
                    Login(username, selectedRole);
                }
                else
                {
                    MessageBox.Show("Invalid admin credentials.");
                }
            }
            else if (selectedRole == "Client")
            {
                if (clients.ContainsKey(username) && clients[username] == password)
                {
                    MessageBox.Show("Client logged in successfully!");
                    Login(username, selectedRole);
                }
                else
                {
                    MessageBox.Show("Invalid client credentials.");
                }
            }
        }
        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string selectedRole = comboBox1.SelectedItem.ToString();

                if (selectedRole == "Client")
                {
                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        if (clients.ContainsKey(username))
                        {
                            MessageBox.Show("Client username already exists.");
                        }
                        else
                        {
                            clients.Add(username, password);
                            MessageBox.Show("Client registered successfully!");

                            // Automatically log in the client after successful registration
                            Login(username, selectedRole);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid username and password.");
                    }
                }
                else
                {
                    MessageBox.Show("Admin cannot be registered.");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace LoginScreen.MVC.View
{
    public partial class frmRegisterView : Form
    {
        public frmRegisterView()
        {
            InitializeComponent();
        }
        private void frmRegisterView_Load(object sender, EventArgs e)
        {

        }
        string connectionString = "server=localhost;user=root;database=vacationmanager_db;port=3306;password=''; pooling = false; convert zero datetime=True";
        string connStr = "server=localhost;user=root;database=vacationmanager_db;port=3306;password=''; pooling = false; convert zero datetime=True";
        public bool Register(string username, string password)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = $"SELECT username FROM users WHERE username = '{username}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (!rdr.Read())
                {

                    rdr.Close();
                    sql = $"INSERT INTO users (username, password) VALUES ('{username}', '{password}');";
                    cmd = new MySqlCommand(sql, conn);
                    rdr = cmd.ExecuteReader();


                }
                else
                {
                    MessageBox.Show("This username is already!");
                }

                rdr.Close();
                conn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void btnLog_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register(txtUsername.Text, txtPassword.Text);
        }
    }
}

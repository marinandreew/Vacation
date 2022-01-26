using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace VacationManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                //Свързване на базата данни
                SqlConnection con = Table();
                con.Open();
                MessageBox.Show("Successfully Inserted.");
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

            SqlConnection Table()
            {
                //Свързване на базаданни
                String str = "Data Source=localhost;Initial Catalog=FormDb;Integrated Security=True;Pooling=False";
                //Вмъкване на данни от форма
                String query = "INSER INTO DataTb(Id, Username, Team) values('" + int.Parse(txtID.Text) + "', '" + txtUsername.Text + "', '" + cmBox.Text + "'";
                //От декларацията го конвентираме в SQL 
                SqlConnection con = new SqlConnection(str);
                //Готова заявка
                SqlCommand cmd = new SqlCommand(query, con);
                return con;
            }


        }


    }
}

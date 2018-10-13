using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DBconnection
{
    public partial class MainForm : Form
    {
        string connectionString;
        SqlConnection cnn;
        public MainForm()
        {
            InitializeComponent();
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MRB\source\repos\PSRES\DBconnection\Database1.mdf;Integrated Security=True";
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            populate();
           
        }

        private void populate()
        {
            using (cnn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM RECIPE", cnn))
            {
                DataTable recipetable = new DataTable();
                adapter.Fill(recipetable);
                listrecipes.DataSource = recipetable;
                listrecipes.ValueMember = "Id";
                listrecipes.DisplayMember = "Name";
            }
        }
    }
}

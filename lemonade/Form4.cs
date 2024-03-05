using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lemonade
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void BindGrid()
        {
            string constring = @"Data Source=CASLAB82D-PC03;database=marketplace;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSales", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    con.Close();
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime begining = dateTimePicker1.Value.Date;
            //MessageBox.Show(begining.ToString());
            DateTime ending = dateTimePicker2.Value.Date;
            string constring = @"Data Source=CASLAB82D-PC03;database=marketplace;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
            string query = "SELECT * FROM tblSales WHERE datePurchase BETWEEN @BeginDate AND @EndDate";
            using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BeginDate", begining);
                    cmd.Parameters.AddWithValue("@EndDate", ending.AddDays(1));
                    //cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    adapter.Fill(dt); 
                    dataGridView1.DataSource = dt;
                    decimal totalSales = CalculateTotalSales(dt);
                    textBox1.Text = totalSales.ToString("C");
                    con.Close();
                }
            }
        }
        private decimal CalculateTotalSales(DataTable salesData)
        {
            decimal totalSales = 0;
            foreach (DataRow row in salesData.Rows)
            {
                totalSales += Convert.ToDecimal(row["amount"]);
            }
            return totalSales;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            BindGrid();
        }


    }
}

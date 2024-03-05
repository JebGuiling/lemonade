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
    public partial class Form3 : Form
    {
        String uname = "none";
        String upass = "none";
        public static string setfirstname = "";
        public static string setlastname = "";
        public static string setuserlevel = "";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void BindGrid()
        {
            string constring = @"Data Source=CASLAB82D-PC03;database=login;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Login where Username = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", con))
                {
                cmd.CommandType = CommandType.Text; 
                con.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dt;
                if (dataGridView1.Rows.Count > 1)
                {
                    uname = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    upass = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    setfirstname = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    setlastname = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    setuserlevel = dataGridView1.Rows[0].Cells[5].Value.ToString();
                }
            }
        }
    }

        private void button1_Click(object sender, EventArgs e)
        {
            BindGrid();
            if ((textBox1.Text == uname) && (textBox2.Text == upass))
            {
                if (setuserlevel == "Owner")
                {
                    Form f1 = new Form1();
                    f1.Show();
                }
                else
                {
                    Form f1 = new Form1();
                    f1.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid Username/Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

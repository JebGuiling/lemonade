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
    public partial class Form1 : Form
    {

        double total = 0;
        int transactionNo = 0;
        double change = 0;
        public Form1()
        {
            InitializeComponent();
            button11.Enabled = false;
            button12.Enabled = false;

            BindGrid();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Quantity for Chicken");
            }
            else
            {
                total = 300 * double.Parse(textBox2.Text) + total;
                Amount = 300 * double.Parse(textBox2.Text);
                textBox5.Text = total.ToString();
                button2.Enabled = false;
                dataGridView1.Rows.Add(transactionNo, "Chicken", 300.00, textBox2.Text, Amount, DateTime.Now);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Quantity for Fish");
            }
            else
            {
                total = 200 * double.Parse(textBox1.Text) + total;
                Amount = 200 * double.Parse(textBox1.Text);
                textBox5.Text = total.ToString();
                button1.Enabled = false;
                dataGridView1.Rows.Add(transactionNo, "Fish", 200.00, textBox1.Text, Amount, DateTime.Now);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button12.Enabled = true;
            total = 0;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;



            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";


            textBox5.Text = "0";

            dataGridView1.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter Quantity for Beef");
            }
            else
            {
                total = 250 * double.Parse(textBox3.Text) + total;
                Amount = 250 * double.Parse(textBox3.Text);
                textBox5.Text = total.ToString();
                button3.Enabled = false;
                dataGridView1.Rows.Add(transactionNo, "Beef", 250.00, textBox3.Text, Amount, DateTime.Now);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Quantity for Pork");
            }
            else
            {
                total = 350 * double.Parse(textBox4.Text) + total;
                Amount = 350 * double.Parse(textBox4.Text);
                textBox5.Text = total.ToString();
                button4.Enabled = false;
                dataGridView1.Rows.Add(transactionNo, "Pork", 350.00, textBox4.Text, Amount, DateTime.Now);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox9.Text == "")
            {
                MessageBox.Show("Enter Quantity for Onion");
            }
            else
            {

                total = 50 * double.Parse(textBox9.Text) + total;
                Amount = 50 * double.Parse(textBox9.Text);
                textBox5.Text = total.ToString();
                button10.Enabled = false;
                dataGridView1.Rows.Add(transactionNo, "Onion", 50.00, textBox9.Text, Amount, DateTime.Now);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox8.Text == "")
            {
                MessageBox.Show("Enter Quantity for Spring Onion");
            }
            else
            {
                total = 40 * double.Parse(textBox8.Text) + total;
                Amount = 40 * double.Parse(textBox8.Text);
                textBox5.Text = total.ToString();
                button9.Enabled = false;
                dataGridView1.Rows.Add(transactionNo, "Spring Onion", 40.00, textBox8.Text, Amount, DateTime.Now);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox7.Text == "")
            {
                MessageBox.Show("Enter Quantity for Eggplant");
            }
            else
            {
                total = 60 * double.Parse(textBox7.Text) + total;
                Amount = 60 * double.Parse(textBox7.Text);
                textBox5.Text = total.ToString();
                button8.Enabled = false;
                dataGridView1.Rows.Add(transactionNo, "Eggplant", 60.00, textBox7.Text, Amount, DateTime.Now);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox6.Text == "")
            {
                MessageBox.Show("Enter Quantity for Apple");
            }
            else
            {
                total = 40 * double.Parse(textBox7.Text) + total;
                Amount = 40 * double.Parse(textBox7.Text);
                textBox5.Text = total.ToString();
                button7.Enabled = false;
                dataGridView1.Rows.Add(transactionNo, "Apple", 40.00, textBox7.Text, Amount, DateTime.Now);
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            transactionNo = rnd.Next();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button12.Enabled = true;
            string constring = @"Data Source=CASLAB82D-PC03;database=marketplace;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblOrder(TNO, item, price, qty, amount, dateOrder) VALUES (@TNO, @item, @price, @qty, @amount, @dateOrder)", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@TNO", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@item", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@qty", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@amount", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@dateOrder", SqlDbType.DateTime));

                    con.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@TNO"].Value = row.Cells[0].Value;
                            cmd.Parameters["@Item"].Value = row.Cells[1].Value;
                            cmd.Parameters["@Price"].Value = row.Cells[2].Value;
                            cmd.Parameters["@Qty"].Value = row.Cells[3].Value;
                            cmd.Parameters["@amount"].Value = row.Cells[4].Value;
                            cmd.Parameters["@dateOrder"].Value = row.Cells[5].Value; 
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            total = 0;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            


            dataGridView1.Rows.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=CASLAB82D-PC03;database=marketplace;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblSales(TNO, item, price, qty, amount, datePurchase) VALUES (@TNO, @item, @price, @qty, @amount, @datePurchase)", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@TNO", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@item", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@qty", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@amount", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@datePurchase", SqlDbType.DateTime));

                    con.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@TNO"].Value = row.Cells[0].Value;
                            cmd.Parameters["@item"].Value = row.Cells[1].Value;
                            cmd.Parameters["@price"].Value = row.Cells[2].Value;
                            cmd.Parameters["@qty"].Value = row.Cells[3].Value;
                            cmd.Parameters["@amount"].Value = row.Cells[4].Value;
                            cmd.Parameters["@datePurchase"].Value = row.Cells[5].Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                BindGrid();

            }
        }
        private void BindGrid()
        {
            string constring = @"Data Source=CASLAB82D-PC03;database=marketplace;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSales",con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView2.DataSource = dt;
                    con.Close();
                }

            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            button11.Enabled = true;
            double x = double.Parse(textBox10.Text);
            double y = double.Parse(textBox5.Text);
            if (x >= y)
            {
                double change = double.Parse(textBox10.Text) -
               double.Parse(textBox5.Text);
                textBox11.Text = change.ToString();
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form f4 = new Form4();
            f4.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}




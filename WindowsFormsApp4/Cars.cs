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

namespace WindowsFormsApp4
{
    public partial class Cars : Form
    {
        public DataGridViewRow row { get; set; }
        public SqlConnection con { get; set; }
        public Cars()
        {
            InitializeComponent();
            sqlConnection1.ConnectionString = "Data Source= " + System.Environment.MachineName + ";Initial Catalog=ArendaAvto;Integrated Security=True";

        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql;

            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();
            {
                if (row == null)
                {
                    sql = "INSERT INTO Cars (CarBrand, Price, CarMileage, GosNomer, GodVipuska, NalichieAuto) VALUES ('" 
                        + textBox1.Text + "','" 
                        + textBox2.Text + "','" 
                        + textBox3.Text + "','"
                        + textBox4.Text + "','"
                        + textBox5.Text + "','"
                        + textBox6.Text + "')";
                }
                else
                {
                    double num = Convert.ToDouble(textBox2.Text);
                    sql = "UPDATE Cars SET CarBrand = '" + textBox1.Text +
                        "',  Price = '" + Convert.ToString(num) + 
                        "', CarMileage = '" + textBox3.Text + 
                        "',  GosNomer = '" + textBox4.Text + 
                        "',  GodVipuska = '" + textBox5.Text + 
                        "',  NalichieAuto = '" + textBox6.Text +
                        "' WHERE ID = '" + Convert.ToString(row.Cells[0].Value) + "'";
                }
            }
            SqlCommand cmd = new SqlCommand(sql, sqlConnection1);
            cmd.ExecuteNonQuery();
            Close();
        }
        private void Cars_Load(object sender, EventArgs e)
        {
            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();

            if (row == null)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();

            }
            else
            {
                textBox1.Text = Convert.ToString(row.Cells[1].Value);
                textBox2.Text = Convert.ToString(row.Cells[2].Value);
                textBox3.Text = Convert.ToString(row.Cells[3].Value);
                textBox4.Text = Convert.ToString(row.Cells[4].Value);
                textBox5.Text = Convert.ToString(row.Cells[5].Value);
                textBox6.Text = Convert.ToString(row.Cells[6].Value);

            }

        }
    }
}

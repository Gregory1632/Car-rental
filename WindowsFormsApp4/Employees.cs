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
    public partial class Employees : Form
    {
        public DataGridViewRow row { get; set; }
        public SqlConnection con { get; set; }
        public Employees()
        {
            InitializeComponent();
            sqlConnection1.ConnectionString = "Data Source= " + System.Environment.MachineName + ";Initial Catalog=ArendaAvto;Integrated Security=True";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;

            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();
            {
                if (row == null)
                {
                    sql = "INSERT INTO Employees (FullName, Number, address) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                }
                else
                {
                    sql = "UPDATE Employees SET FullName = '" + textBox1.Text + "',  Number = '" + textBox2.Text + "', Address = '" + textBox3.Text + "' WHERE ID = '" + Convert.ToString(row.Cells[0].Value) + "'";
                }
            }
            SqlCommand cmd = new SqlCommand(sql, sqlConnection1);
            cmd.ExecuteNonQuery();
            Close();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();

            if (row == null)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

            }
            else
            {
                textBox1.Text = Convert.ToString(row.Cells[1].Value);
                textBox2.Text = Convert.ToString(row.Cells[2].Value);
                textBox3.Text = Convert.ToString(row.Cells[3].Value);

            }
        }
    }
}

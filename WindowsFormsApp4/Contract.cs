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
    public partial class Contract : Form
    {
        public DataGridViewRow row { get; set; }
        public SqlConnection con { get; set; }
        public Contract()
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
                    sql = "INSERT INTO Contract (ReturnTime, TimeOfIssue, Status, IDCars, IDClient, IDEmployees) VALUES ('" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox3.Text + "','" + Convert.ToInt32(comboBox1.SelectedValue) + "','" + Convert.ToInt32(comboBox2.SelectedValue) + "','" + Convert.ToInt32(comboBox3.SelectedValue) + "')";
                }
                else
                {
                    sql = "UPDATE Contract SET ReturnTime = '" + dateTimePicker1.Text + "',  TimeOfIssue = '" + dateTimePicker2.Text + "', Status = '" + textBox3.Text + "', IDCars = '" + Convert.ToInt32(comboBox1.SelectedValue) + "', IDClient = '" + Convert.ToInt32(comboBox2.SelectedValue) + "', IDEmployees = '" + Convert.ToInt32(comboBox3.SelectedValue) + "' WHERE ID = '" + Convert.ToString(row.Cells[0].Value) + "'";
                }
            }
            SqlCommand cmd = new SqlCommand(sql, sqlConnection1);
            cmd.ExecuteNonQuery();
            Close();
        }
        private void FillComboBox(string Sqlquery, ref ComboBox combo, string sDisplayMember, string sValueMember)
        {

            SqlCommand comm = new SqlCommand(Sqlquery, sqlConnection1);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            DataTable fTable = new DataTable();
            adapter.Fill(fTable);
            combo.DataSource = fTable.DefaultView;
            combo.DisplayMember = sDisplayMember;
            combo.ValueMember = sValueMember;
            combo.SelectedIndex = 0;
        }

        private void Contract_Load(object sender, EventArgs e)
        {
            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();

            FillComboBox("SELECT * FROM Cars", ref comboBox1, "CarBrand", "ID");
            FillComboBox("SELECT * FROM Client", ref comboBox2, "FullName", "ID");
            FillComboBox("SELECT * FROM Employees", ref comboBox3, "FullName", "ID");

            if (row == null)
            {
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
                textBox3.Clear();
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
            }
            else
            {
                dateTimePicker1.Text = Convert.ToString(row.Cells[1].Value);
                dateTimePicker2.Text = Convert.ToString(row.Cells[2].Value);
                textBox3.Text = Convert.ToString(row.Cells[5].Value);
                comboBox1.SelectedValue = Convert.ToInt32(row.Cells[6].Value);
                comboBox2.SelectedValue = Convert.ToInt32(row.Cells[3].Value);
                comboBox3.SelectedValue = Convert.ToInt32(row.Cells[4].Value);
            }
        }
    }
}

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
    public partial class CarPark : Form
    {
        public DataGridViewRow row { get; set; }
        public SqlConnection con { get; set; }
        public CarPark()
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
                    sql = "INSERT INTO CarPark (PlaceNumber, IDCars) VALUES ('" + textBox1.Text + "','" + Convert.ToInt32(comboBox1.SelectedValue) + "')";
                }
                else
                {
                    sql = "UPDATE CarPark SET PlaceNumber = '" + textBox1.Text + "',  IDCars = '" + Convert.ToInt32(comboBox1.SelectedValue) + "' WHERE ID = '" + Convert.ToString(row.Cells[0].Value) + "'";
                }
            }
            SqlCommand cmd = new SqlCommand(sql, sqlConnection1);
            cmd.ExecuteNonQuery();
            Close();
        }


        private void CarPark_Load(object sender, EventArgs e)
        {
            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();

            FillComboBox("SELECT * FROM Cars", ref comboBox1, "CarBrand", "ID");

            if (row == null)
            {
                textBox1.Clear();
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                textBox1.Text = Convert.ToString(row.Cells[1].Value);
                comboBox1.SelectedValue = Convert.ToInt32(row.Cells[2].Value);

            }
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
    }
}

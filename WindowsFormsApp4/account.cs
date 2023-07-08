using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class account : Form
    {
        public DataGridViewRow row { get; set; }
        public SqlConnection con { get; set; }

        int countClick = 0;
        bool fgood;

        public account()
        {
            InitializeComponent();
            sqlConnection1.ConnectionString = "Data Source= " + System.Environment.MachineName
                + ";Initial Catalog=ArendaAvto;Integrated Security=True";
        }
        //добавление аккаунта

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;

            //if (row == null)
            //{
            //    textBox1.Clear();
            //    textBox2.Clear();
            //    textBox3.Clear();

            //    comboBox2.SelectedIndex = 0;
            //    comboBox2.SelectedIndex = 0;


            //}

            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();
            {
                sql = "INSERT INTO Account (Login, Password, IDEmployees, UserType) VALUES ('"
                            + textBox1.Text + "','"
                            + textBox2.Text + "','"
                            + Convert.ToString(comboBox2.SelectedValue) + "','"
                            + textBox3.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection1);
                cmd.ExecuteNonQuery();
                dsaccount1.Clear();
                sqlDataAdapter1.Fill(dsaccount1);
            }
        }
        //изменение аккаунта
        private void button5_Click(object sender, EventArgs e)
        {
            string sql;

            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();
            // Выбор столбца
            row = dataGridView1.CurrentRow;
            con = sqlConnection1;

            if (row == null)
            {
                MessageBox.Show("Выберите изменяемую строку.");
            }
            else
            {

                textBox1.Text = Convert.ToString(row.Cells[1].Value);
                textBox2.Text = Convert.ToString(row.Cells[2].Value);
                textBox3.Text = Convert.ToString(row.Cells[3].Value);
                comboBox2.SelectedValue = Convert.ToString(row.Cells[4].Value);

                countClick = 1;

                button5.Visible = false;
                button2.Visible = true;
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }
        //сохранить изменения
        private void button2_Click(object sender, EventArgs e)
        {
            string sql;

            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();
            {
                sql = "UPDATE Account SET IDEmployees = '" + Convert.ToString(comboBox2.SelectedValue)
                        + "',  Login = '" + textBox1.Text
                        + "', Password = '" + textBox2.Text
                        + "', UserType = '" + textBox3.Text
                        + "' WHERE ID = '" + Convert.ToString(row.Cells[0].Value) + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, sqlConnection1);
            cmd.ExecuteNonQuery();
            dsaccount1.Clear();
            sqlDataAdapter1.Fill(dsaccount1);

            button5.Visible = true;
            button2.Visible = false;
            button1.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        //удаление аккаунта
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("delete from Account where ID ='" + Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value) + "'", sqlConnection1);
                cmd.ExecuteNonQuery();
                dsaccount1.Clear();
                sqlDataAdapter1.Fill(dsaccount1);
                cmd.Dispose();
            }
            else MessageBox.Show("No Row");
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

        private void Form2_Load(object sender, EventArgs e)
        {
            sqlDataAdapter1.Fill(dsaccount1);
            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();

            // Заполнение ComboBox
            FillComboBox("SELECT * FROM Employees", ref comboBox2, "FullName", "ID");
            

            button2.Visible = false;

        }
    }
}

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
    public partial class reg : Form
    {
        int count = 3;
        bool fgood;
        public reg()
        {
            InitializeComponent();
            sqlConnection1.ConnectionString = "Data Source= " + System.Environment.MachineName + ";Initial Catalog=ArendaAvto;Integrated Security=True";
            fgood = false;
        }
        //запрет на закрытие формы крестом
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!fgood)
                e.Cancel = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Логин или пароль пуст");
                return;
            }
            if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();

            DataTable useresTable = new DataTable();
            SqlCommand comm = new SqlCommand("SELECT * FROM Account WHERE Login = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'", sqlConnection1);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            adapter.Fill(useresTable);
            comm.ExecuteNonQuery();
            if (useresTable.Rows.Count > 0)
            {

                MessageBox.Show("Успешно");
                AccountData.Id = Convert.ToInt32(useresTable.Rows[0][0].ToString());
                AccountData.Text = useresTable.Rows[0][3].ToString();
                fgood = true;
                Close();
            }
            else
            {
                count--;
                if (count == 0)
                {
                    button1.Enabled = false;
                }
                MessageBox.Show("Неверный логин или пароль, осталось " + count + " попытки");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void reg_Load(object sender, EventArgs e)
        {

        }
    }
}

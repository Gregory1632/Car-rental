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
    public partial class Main : Form
    {


        public Main()
        {
            InitializeComponent();
            sqlConnection1.ConnectionString = "Data Source= " + System.Environment.MachineName + ";Initial Catalog=ArendaAvto;Integrated Security=True";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlDataAdapter3.Fill(dscontract1);
            sqlDataAdapter1.Fill(dsclient1);
            sqlDataAdapter2.Fill(dsemp1);
            sqlDataAdapter4.Fill(dscars1);
            sqlDataAdapter5.Fill(dscarpark1);

            reg log = new reg();
            log.ShowDialog();
        }
       
        //удалить клиента
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("delete from Client where ID ='" + Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value) + "'", sqlConnection1);
                cmd.ExecuteNonQuery();
                dsclient1.Clear();
                sqlDataAdapter1.Fill(dsclient1);
                cmd.Dispose();
                MessageBox.Show("Удалено");
            }
            else
                MessageBox.Show("No Row");
            dscontract1.Clear();
            sqlDataAdapter1.Fill(dsclient1);
        }
        //добавить контракт
        private void button6_Click(object sender, EventArgs e)
        {
            Contract form2 = new Contract();
            form2.Show();
            form2.row = null;
            form2.con = sqlConnection1;
            form2.Visible = false;
            form2.ShowDialog();
            dscontract1.Clear();
            sqlDataAdapter3.Fill(dscontract1);
        }
        //добавить машину
        private void button8_Click(object sender, EventArgs e)
        {
            Cars form2 = new Cars();
            form2.Show();
            form2.row = null;
            form2.con = sqlConnection1;
            form2.Visible = false;
            form2.ShowDialog();
            dscontract1.Clear();
            sqlDataAdapter4.Fill(dscars1);
        }
        //добавить парковку
        private void button10_Click(object sender, EventArgs e)
        {
            CarPark form2 = new CarPark();
            form2.Show();
            form2.row = null;
            form2.con = sqlConnection1;
            form2.Visible = false;
            form2.ShowDialog();
            dscontract1.Clear();
            sqlDataAdapter5.Fill(dscarpark1);
        }
        // удалить работника
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("delete from Employees where ID ='" + Convert.ToString(dataGridView2.CurrentRow.Cells[0].Value) + "'", sqlConnection1);
                cmd.ExecuteNonQuery();
                dsemp1.Clear();
                sqlDataAdapter2.Fill(dsemp1);
                cmd.Dispose();
                MessageBox.Show("Удалено");
            }
            else
                MessageBox.Show("No Row");
        }
        //добавить сотрудника
        private void button3_Click_1(object sender, EventArgs e)
        {
            Employees Employees = new Employees();
            Employees.Show();
            Employees.row = null;
            Employees.con = sqlConnection1;
            Employees.Visible = false;
            Employees.ShowDialog();
            dsemp1.Clear();
            sqlDataAdapter2.Fill(dsemp1);
        }
        //добавить клиента
        private void button1_Click(object sender, EventArgs e)
        {
            Clients form2 = new Clients();
            form2.Show();
            form2.row = null;
            form2.con = sqlConnection1;
            form2.Visible = false;
            form2.ShowDialog();
            dsclient1.Clear();
            sqlDataAdapter1.Fill(dsclient1);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //удалить автомобили
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView4.RowCount > 0)
            {
                if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("delete from Cars where ID ='" + Convert.ToString(dataGridView4.CurrentRow.Cells[0].Value) + "'", sqlConnection1);
                cmd.ExecuteNonQuery();
                dscars1.Clear();
                sqlDataAdapter4.Fill(dscars1);
                cmd.Dispose();
                MessageBox.Show("Удалено");
            }
            else
                MessageBox.Show("No Row");
        }
        //удалить парковку
        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView5.RowCount > 0)
            {
                if (sqlConnection1.State == ConnectionState.Closed) sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("delete from CarPark where ID ='" + Convert.ToString(dataGridView5.CurrentRow.Cells[0].Value) + "'", sqlConnection1);
                cmd.ExecuteNonQuery();
                dscarpark1.Clear();
                sqlDataAdapter5.Fill(dscarpark1);
                cmd.Dispose();
                MessageBox.Show("Удалено");
            }
            else
                MessageBox.Show("No Row");
        }
        //удалить контракт
        private void button5_Click(object sender, EventArgs e)
        {

        }
        //изменить клиента
        private void button11_Click(object sender, EventArgs e)
        {
            Clients form2 = new Clients();
            form2.row = dataGridView1.CurrentRow;
            form2.con = sqlConnection1;
            form2.ShowDialog();
            dsclient1.Clear();
            sqlDataAdapter1.Fill(dsclient1);
            dscontract1.Clear();
            sqlDataAdapter3.Fill(dscontract1);
        }
        //изменить сотрудников
        private void button12_Click(object sender, EventArgs e)
        {
            Employees form2 = new Employees();
            form2.row = dataGridView2.CurrentRow;
            form2.con = sqlConnection1;
            form2.ShowDialog();
            dsemp1.Clear();
            sqlDataAdapter2.Fill(dsemp1);
        }
        //изменить контракт
        private void button13_Click(object sender, EventArgs e)
        {
            Contract form2 = new Contract();
            form2.row = dataGridView3.CurrentRow;
            form2.con = sqlConnection1;
            form2.ShowDialog();
            dscontract1.Clear();
            sqlDataAdapter3.Fill(dscontract1);
        }
        //изменить машины
        private void button14_Click(object sender, EventArgs e)
        {
            Cars form2 = new Cars();
            form2.row = dataGridView4.CurrentRow;
            form2.con = sqlConnection1;
            form2.ShowDialog();
            dscars1.Clear();
            sqlDataAdapter4.Fill(dscars1);
        }
        //изменить парковку
        private void button15_Click(object sender, EventArgs e)
        {
            CarPark form2 = new CarPark();
            form2.row = dataGridView5.CurrentRow;
            form2.con = sqlConnection1;
            form2.ShowDialog();
            dscarpark1.Clear();
            sqlDataAdapter5.Fill(dscarpark1);
        }
        //управление аккаунтом

        private void button16_Click(object sender, EventArgs e)
        {
            if (AccountData.Text == "admin")
            {
                Form2 accountManagment = new Form2();
                accountManagment.ShowDialog();
                accountManagment.row = null;
                accountManagment.con = sqlConnection1;
            }
            else
            {
                MessageBox.Show("Ваш уровень доступа недостаточен!");
                return;
            }
        }
        //смена аккаунтами
        private void button17_Click(object sender, EventArgs e)
        {
            reg authorization = new reg();
            authorization.ShowDialog();
        }
    }
}

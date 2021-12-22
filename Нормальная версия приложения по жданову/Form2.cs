using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Нормальная_версия_приложения_по_жданову
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        private SUBD_Access subd = new SUBD_Access();
        private void Form2_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = subd.MainFormDataTable();


        }

         

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string cost = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string time = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string score = dataGridView1.Rows[index].Cells[4].Value.ToString();

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:/Users/stepk/Desktop/16_111.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "INSERT INTO группы VALUES (" + id + "," + name + ", " + cost + ", " + time + ", " + score +")";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");

            dbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string cost = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string time = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string score = dataGridView1.Rows[index].Cells[4].Value.ToString();

            string connectionString = "provider = Microsoft.Jet.OLEDB.4.0; Data Source =C:/Users/stepk/Desktop/16_111.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = $"UPDATE Успеваемость SET [Название группы] = '{name}', [Средний балл] ={ cost }, [Номер семестр] ={ time } , [Факультет] = {score} WHERE id = " + id;
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
            {
                MessageBox.Show("Данные изменены!", "Внимание!");
            }

            dbConnection.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            {

                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("Выберите одну строку!", "Внимание!");
                    return;
                }


                string connectionString = "provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:/Users/stepk/Desktop/16_111.mdb";
                OleDbConnection dbConnection = new OleDbConnection(connectionString);


                int index = dataGridView1.SelectedRows[0].Index;


                if (dataGridView1.Rows[index].Cells[0].Value == null)
                {
                    MessageBox.Show("Не все данные введены!", "Внимание!");
                    return;
                }


                string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                

                dbConnection.Open();
                string query = "DELETE FROM группы WHERE Название группы =  " + id;
                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

               
                if (dbCommand.ExecuteNonQuery() != 1)
                    MessageBox.Show("Ошибка выполнения запроса!");
                else
                {
                    MessageBox.Show("Данные удалены!");
                    dataGridView1.Rows.RemoveAt(index);
                }


                dbConnection.Close();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}

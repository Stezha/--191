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
using LiveCharts;
using LiveCharts.Wpf;


namespace Нормальная_версия_приложения_по_жданову
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 a = new Form2();
        private SUBD_Access subd = new SUBD_Access();
        private static string path = "provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:/Users/stepk/Desktop/16_111.mdb";
        private OleDbConnection connection = new OleDbConnection(path);

        public DataTable MainFormDataTable()
        {

            string query = $"SELECT * FROM [Успеваемость]";
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = subd.MainFormDataTable();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = subd.MainFormDataTable();


            ChartValues<int> worktime = new ChartValues<int>();
            ChartValues<int> price = new ChartValues<int>();

            for (int i = 0; i< dataGridView1.RowCount; i++)
            {


                worktime.Add(Convert.ToInt32(dataGridView1[2, i].Value));
                price.Add(Convert.ToInt32(dataGridView1[4, i].Value));
            }

            cartesianChart1.AxisX.Clear();

            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Год начала",
            });

            cartesianChart1.AxisY.Clear();

            LineSeries line = new LineSeries();
            line.Title = "Средний балл";
            line.Values = price;
            
            SeriesCollection series = new SeriesCollection();
            series.Add(line);

            cartesianChart1.Series = series;
            cartesianChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Нормальная_версия_приложения_по_жданову
{
    class SUBD_Access
    {
        private static string path = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:/Users/stepk/Desktop/16_111.mdb";
        private OleDbConnection connection = new OleDbConnection(path); 

        public DataTable MainFormDataTable()
        {

            string query = $"SELECT * FROM [группы]";
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            connection.Close();
            return table;

        }
    }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS_Perpustakaan
{
    class Utils
    {
        public static string conn = @"Data Source=desktop-00eposj;Initial Catalog=perpustakaan;Integrated Security=True";
    }

    class Model
    {
        public static string id { set; get; }
        public static string name { set; get; }
        public static string role { set; get; }
        public static int userid { set; get; }
    }

    class Command
    {
        public static void exec(string com)
        {
            SqlConnection connection = new SqlConnection(Utils.conn);
            connection.Open();
            SqlCommand command = new SqlCommand(com, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static DataTable getdata(string com)
        {
            SqlConnection connection = new SqlConnection(Utils.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(com, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }

    class Selected
    {
        public static int id { set; get; }
    }
}

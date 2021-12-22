using System;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DbProviderFactoryCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "server=(local)\\MAYAO;database=MyDB;Integrated Security=true;";
            IDbConnection conn = new SqlConnection(connection);
            string queryString = "SELECT id, name FROM in4";
            using (IDbCommand com = conn.CreateCommand())
            {
                com.CommandType = CommandType.Text;
                com.CommandText = queryString;

                conn.Open();

                using (IDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Display the product details.
                        Console.WriteLine("{0} - {1}",
                            reader["id"],
                            reader["name"]);
                    }
                }

                Console.ReadKey();
            }

        }
    }
}

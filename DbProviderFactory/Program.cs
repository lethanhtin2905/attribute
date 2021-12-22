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
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            using (DbConnection con = factory.CreateConnection())
            {
                con.ConnectionString = "server=(local)\\MAYAO;database=MyDB;Integrated Security=true;";

                using (DbCommand com = con.CreateCommand())
                {
                    com.CommandType = CommandType.Text;
                    com.CommandText = "SELECT id, name FROM in4";

                    con.Open();

                    using (DbDataReader reader = com.ExecuteReader())
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
}

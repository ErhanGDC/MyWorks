using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SelectCommand
{
    class Program
    {
        static void Main(string[] args)
        {
             Task result= SelectDataFromTable();
            Console.ReadLine();
        }

        public static async Task SelectDataFromTable()
        {
            // string connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.ConnectionStrings["CONNECTIONSTRING"].ConnectionString].ConnectionString;
            string connectionString = ConfigurationManager.ConnectionStrings[".CONNECTIONSTRING"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM KEPLER_CUSTOMER", connection);
                await connection.OpenAsync();

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    string formatStringWithMiddleName = "Person ({0}) is named {1} {2} {3}";
                    string formatStringWithoutMiddleName = "Person ({0}) is named {1} {3}";

                    if ((dataReader["Name"] == null))
                    {
                        Console.WriteLine(formatStringWithoutMiddleName,
                        dataReader["Id"],
                        dataReader["Name"],
                        dataReader["Email"]);
                    }
                    else
                    {
                        Console.WriteLine(formatStringWithMiddleName,
                        dataReader["Id"],
                        dataReader["Name"],
                        dataReader["Email"],
                        dataReader["Adress"]);
                    }
                }
                dataReader.Close();
            }
        }
    }
}

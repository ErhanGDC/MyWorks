using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace MultipleSelect
{
    class Program
    {
        static void Main(string[] args)
        {
            //   Task result = SelectDataFromTable();
            // Console.ReadLine();
            //Task update = UpdateRows();
            //Console.ReadLine();
            //Task result1 = SelectDataFromTable();
            //Console.ReadLine();

            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    Task insert = InsertRowWithParameterizedQuery();
                    throw new NullReferenceException();
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            Console.ReadLine();
        }

        public static async Task SelectDataFromTable()
        {
            // string connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.ConnectionStrings["CONNECTIONSTRING"].ConnectionString].ConnectionString;
            string connectionString = ConfigurationManager.ConnectionStrings[".CONNECTIONSTRING"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Executing a SQL query with multiple result sets
                SqlCommand command = new SqlCommand("SELECT * FROM KEPLER_CUSTOMER; SELECT * FROM WF_DATA", connection);
                await connection.OpenAsync();
                SqlDataReader dataReader = await command.ExecuteReaderAsync();
                await ReadQueryResults(dataReader);
                await dataReader.NextResultAsync(); // Move to the next result set
                await ReadQueryResults(dataReader);
                dataReader.Close();
            }
        }

        private static async Task ReadQueryResults(SqlDataReader dataReader)
        {
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
        }

        public static async Task UpdateRows()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[".CONNECTIONSTRING"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "UPDATE KEPLER_CUSTOMER SET Name='John & Erhan' Where Id=3080",
                    connection);
                await connection.OpenAsync();
                int numberOfUpdatedRows = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Updated {0} rows", numberOfUpdatedRows);
            }
        }

        public static async Task InsertRowWithParameterizedQuery()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[".CONNECTIONSTRING"].ConnectionString;

              using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO KEPLER_CUSTOMER([Name], [Adress]) VALUES(@Name,@Adress)", connection);

                command.Parameters.AddWithValue("@Name", "Jesse MEtcalfe");
                command.Parameters.AddWithValue("@Adress", "Coloum ismi yanlış girilmiş");
                connection.Open();
                int numberOfInsertedRows = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Inserted {0} rows", numberOfInsertedRows);
            }
        }
    }
}

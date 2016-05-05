using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"(localdb)\v11.0";
            sqlConnectionStringBuilder.InitialCatalog = "ProgrammingInCSharp";
            string connectionString = sqlConnectionStringBuilder.ToString();

           //string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;
           // using (SqlConnection connection = new SqlConnection(connectionString))
           // {
           //     connection.Open();
           // } 
        }
    }
}

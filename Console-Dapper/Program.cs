using Dapper;
using Microsoft.Data.SqlClient;

namespace Console_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dapper
            // Microsoft.Data.SQLClient

            string connectionString = "Data Source=PCZAC;Initial Catalog=Demo-dapper-cloud;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";



                using SqlConnection connection = new SqlConnection(connectionString);

                IEnumerable<Todo> todos =  connection.Query<Todo>("SELECT * FROM Todo");

                foreach (Todo t in todos)
                {
                    Console.WriteLine($" id : {t.Id} - title : {t.Title}");
                }

        }
    }

    class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Done { get; set; }
    }
}

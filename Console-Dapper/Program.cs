using Dal_Demo_Dapper;
using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace Console_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dapper
            // Microsoft.Data.SQLClient


            TodoRepository repo = new TodoRepository();

            IEnumerable<Todo> todos = repo.GetTodos();

            foreach (Todo t in todos)
            {
                Console.WriteLine($"id : {t.Id} - title : {t.Title}");
            }




        }
    }
}

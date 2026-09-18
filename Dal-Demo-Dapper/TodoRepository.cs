using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal_Demo_Dapper
{
    public class TodoRepository
    {
        string connectionString = "Data Source=PCZAC;Initial Catalog=Demo-dapper-cloud;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
        public IEnumerable<Todo> GetTodos()
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            return connection.Query<Todo>("SELECT id,title,description,CreatedAt,Done FROM Todo");

        }

        public Todo? GetById(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            return connection.QueryFirstOrDefault<Todo>($"SELECT id,title,description,CreatedAt,Done FROM Todo WHERE id = @Id", new {Id  = id});
        }
        
    }
}

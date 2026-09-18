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

        /*
         * 
         *  Il est nécéssaire de d'abord crée la base de donnée 
         * 
         * Query<T> : Map le résultat vers une collection
         *
         * QueryFirst<T> : Renvoie le premier résultat ou lève une exception
         *
         * QueryFirstOrDefault<T> : Renvoie le premier résultat ou le null
         *
         * ExecuteScalar<T> : Renvoie une valeur scalaire ( une seule valeur )
         *
         * Execute : execute la requette et récupère le nombre de ligne traité         
         */

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
        
        public Todo? AddTodo(CreateTodo newTodo)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            int result = conn.ExecuteScalar<int>("INSERT INTO Todo (title , description) OUTPUT INSERTED.Id VALUES (@Title , @Description)",
                                    newTodo);

            Todo? todoCreate = GetById(result);

            return todoCreate;
        }
        
        public Todo? UpdateTodo(UpdateTodo updatedTodo,int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            int rows = conn.Execute("UPDATE Todo SET title = @Title , Description = @Description ,Done = @Done WHERE Id = @Id ",
                new { Title = updatedTodo.Title, Description = updatedTodo.Description, Done = updatedTodo.Done, Id = id });

            if(rows  != 0)
            {
                return GetById(id);
            }

            return null;
        }

        public bool DeleteTodo(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);

            int rows = conn.Execute("DELETE FROM Todo WHERE Id = @Id ", new { Id = id });

            return rows > 0;
        }
    }
}

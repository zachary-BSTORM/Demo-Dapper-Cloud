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

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Afficher les taches 1");
                Console.WriteLine("Afficher une tache 2");

                string response = Console.ReadLine();


                switch (response)
                {
                    case "1":
                        IEnumerable<Todo> todos = repo.GetTodos();

                        Console.WriteLine("-------------------------------------");
                        foreach (Todo t in todos)
                        {
                            Console.WriteLine($"id : {t.Id} - title : {t.Title} - description : {t.Description}");
                        }
                        Console.WriteLine("-------------------------------------");
                        Console.ReadLine();
                        break;
                    case "2":
                        IEnumerable<Todo> todosForDetails = repo.GetTodos();

                        Console.WriteLine("-------------------------------------");
                        foreach (Todo t in todosForDetails)
                        {
                            Console.WriteLine($"id : {t.Id} - title : {t.Title} ");
                        }
                        Console.WriteLine("-------------------------------------");

                        Console.WriteLine("Entrez l'id de la tache :");
                        int id = int.Parse(Console.ReadLine());

                        Todo todo = repo.GetById(id);

                        if (todo is not null)
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine($"Titre : {todo.Title}");
                            Console.WriteLine($"Description : {todo.Description}");
                            Console.WriteLine($"Date : {todo.CreatedAt}");
                            Console.WriteLine($"Terminé : {todo.Done}");
                            Console.WriteLine("-------------------------------------");

                        }
                        else
                        {
                            Console.WriteLine($"Aucune tache avec l' id : {id}");
                        }
                        Console.ReadLine();
                        break;
                }
            }

        }
    }
}

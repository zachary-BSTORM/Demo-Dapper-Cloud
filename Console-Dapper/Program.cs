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
                showMenu();

                string response = Console.ReadLine();


                switch (response)
                {
                    case "1":
                        // Affichage de la liste
                        ShowListTodo();
                        Console.ReadLine();
                        break;
                    case "2":
                        // Détails d'une tache
                        ShowListTodo();

                        int id = GetInt("L'id de la tache");

                        Todo todo = repo.GetById(id);

                        if (todo is not null)
                        {
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine(todo);
                            Console.WriteLine("-------------------------------------");

                        }
                        else
                        {
                            Console.WriteLine($"Aucune tache avec l' id : {id}");
                        }
                        Console.ReadLine();
                        break;
                    case "3":
                        // Ajout d'une tache
                        CreateTodo newTodo = GetNewTodo();

                        Todo? todoCreate = repo.AddTodo(newTodo);

                        if(todoCreate is not null)
                        {
                            Console.WriteLine($"Nouvelle tache : id : {todoCreate.Id} - titre : {todoCreate.Title}");
                        }
                        else
                        {
                            Console.WriteLine("Une erreur est survenue lors de l'ajout");
                        }

                        Console.ReadLine();
                        break;
                    case "4":
                        // Modification d'une tache
                        ShowListTodo();
                        int idToUpdate = GetInt("l'id de la tache à modifier");

                        Todo? todoToUpdate = repo.GetById(idToUpdate);

                        if(todoToUpdate is not null)
                        {
                            UpdateTodo updatedTodo = GetUpdatedTodo(todoToUpdate);

                            Todo? todoUpdated = repo.UpdateTodo(updatedTodo,idToUpdate);

                            if(todoUpdated is not null)
                            {
                                Console.WriteLine($"La tache :{todoUpdated.Id} à bien été mis à jour : titre : {todoUpdated.Title}");
                            }
                            else
                            {
                                Console.WriteLine("Une erreur est survenue");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aucune tache ne correspond à cet id");
                        }

                        Console.ReadLine();
                        break;
                    case "5":
                        // Suppression d'une tache
                        ShowListTodo();

                        int idForDelete = GetInt("l'id de la tache à supprimer");

                        bool result = repo.DeleteTodo(idForDelete);

                        if (result)
                        {
                            Console.WriteLine($"La tache {idForDelete} à bien été supprimé");
                        }
                        else
                        {
                            Console.WriteLine("Une erreur est survenue lors de la suppression");
                        }

                        Console.ReadLine();
                        break;
                    case "6":
                        exit = true;
                        break;
                }
            }


            void showMenu()
            {
                Console.Clear();
                Console.WriteLine("Afficher les taches 1");
                Console.WriteLine("Afficher une tache 2");
                Console.WriteLine("Ajouter une tache 3");
                Console.WriteLine("Modifier une tache 4");
                Console.WriteLine("Supprimer une tache 5");
                Console.WriteLine("Quitter  6");
            }

            void ShowListTodo()
            {
                IEnumerable<Todo> todos = repo.GetTodos();

                Console.WriteLine("-------------------------------------");
                foreach (Todo t in todos)
                {
                    Console.WriteLine($"id : {t.Id} - title : {t.Title} - description : {t.Description}");
                }
                Console.WriteLine("-------------------------------------");
            }

            int GetInt(string message)
            {
                int result = 0;
                do
                {
                    Console.WriteLine($"Entrer la valeur pour :{message}");

                } while (!int.TryParse(Console.ReadLine(), out result));

                return result;
            }

            CreateTodo GetNewTodo()
            {
                Console.WriteLine("Entrez le titre de la tache :");
                string title = Console.ReadLine();

                Console.WriteLine("Entrez la description :");
                string description = Console.ReadLine();

                CreateTodo newTodo = new(title,description);

                return newTodo;
            }

            UpdateTodo GetUpdatedTodo(Todo todoToUpdate)
            {
                Console.WriteLine($"Titre : {todoToUpdate.Title}");
                string titleForUpdate = Console.ReadLine();

                Console.WriteLine($"Description : {todoToUpdate.Description}");
                string descriptionForUpdate = Console.ReadLine();

                Console.WriteLine($"Terminé : {todoToUpdate.Done}");
                Console.WriteLine("true / false");
                bool doneForUpdate = bool.Parse(Console.ReadLine());

                UpdateTodo updatedTodo = new(titleForUpdate,descriptionForUpdate,doneForUpdate);

                return updatedTodo;
            }
        }
    }
}

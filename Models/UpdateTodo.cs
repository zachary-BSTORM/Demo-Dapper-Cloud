using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class UpdateTodo
    {

        public UpdateTodo(string title, string description,bool done)
        {
            this.Title = title;
            this.Description = description;
            this.Done = done;
        }
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }
    }
}

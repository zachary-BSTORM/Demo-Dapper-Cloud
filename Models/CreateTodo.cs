using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CreateTodo
    {

        public CreateTodo(string title,string description)
        {
            this.Title = title;
            this.Description = description;
        }
        public string Title { get; set; }

        public string Description { get; set; }
    }
}

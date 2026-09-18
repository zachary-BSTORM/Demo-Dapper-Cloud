using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Done { get; set; }
    }
}

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

        public override string  ToString()
        {
            return  $" id               : {this.Id} \n" +
                    $" title            : {this.Title}\n" +
                    $" description      : {this.Description}\n" +
                    $" DateDeCréation   : {this.CreatedAt.ToShortDateString()}\n" +
                    $" Terminé          : {this.Done}\n";
        }
    }
}

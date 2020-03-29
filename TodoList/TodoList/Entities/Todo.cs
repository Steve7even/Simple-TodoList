using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Entities
{
    public class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int Pkey { get; set; }

        public string Titel { get; set; }

        public string Content { get; set; }
    }
}

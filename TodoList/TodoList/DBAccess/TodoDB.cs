using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities;

namespace TodoList.DBAccess
{


    public class TodoDB
    {
        readonly SQLiteAsyncConnection db;

        public TodoDB()
        {
            db = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "simpletododb.db3"));
            db.CreateTableAsync<Todo>().Wait();
        }

        public Task<List<Todo>> GetAll()
        {
            return db.Table<Todo>().ToListAsync();
        }

        public Task<int> Save(Todo todo)
        {
            if (todo.Pkey == 0)
            {
                return db.InsertAsync(todo);
            }
            else
            {
                return db.UpdateAsync(todo);
            }
        }

        internal void Delete(Todo item)
        {
            db.DeleteAsync(item);
        }
    }
}

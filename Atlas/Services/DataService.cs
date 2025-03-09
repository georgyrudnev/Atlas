using Atlas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlas.Services
{
    public class DataService
    {
        private readonly SQLiteConnection _db;

        public DataService()
        {
            _db = new SQLiteConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "atlas.db3"
            ));

            CreateTables();
        }

        private void CreateTables()
        {
            _db.CreateTable<Book>();
            _db.CreateTable<TodoItem>();
            //_db.CreateTable<LearningItem>();
        }

        #region Book Operations
        public List<Book> GetAllBooks() => _db.Table<Book>().ToList();

        public void SaveBook(Book book)
        {
            if (book.Id == 0)
                _db.Insert(book);
            else
                _db.Update(book);
        }

        public void DeleteBook(Book book) => _db.Delete(book);
        #endregion

        #region Todo Operations
        public List<TodoItem> GetAllTodos() => _db.Table<TodoItem>().ToList();

        public void SaveTodo(TodoItem todo)
        {
            if (todo.Id == 0)
                _db.Insert(todo);
            else
                _db.Update(todo);
        }
        #endregion
    }
}

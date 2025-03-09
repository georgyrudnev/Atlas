using Atlas.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlas.Services
{
    public class BaseRepository<T> : IRepository<T> where T : IEntity, new()
    {
        private SQLiteConnection _db;

        public BaseRepository(SQLiteConnection db)
        {
            _db = db;
            _db.CreateTable<T>();
        }
        // Implement all interface methods
        public Task<List<T>> GetAll() => Task.FromResult(_db.Table<T>().ToList());
        public Task<T> GetById(int id) => Task.FromResult(_db.Find<T>(id));
        public Task Add(T entity) => Task.Run(() => _db.Insert(entity));
        public Task Update(T entity) => Task.Run(() => _db.Update(entity));
        public Task Delete(T entity) => Task.Run(() => _db.Delete(entity));
    }
}

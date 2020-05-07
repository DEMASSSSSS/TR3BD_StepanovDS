using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;
using GameProj.Models;

namespace GameProj
{
    public class BaseRepo<T> : IRepo<T>, IDisposable where T : class
    {
        private readonly DbSet<T> _table;
        private readonly GameDataBase _db;
        protected GameDataBase Context => _db;

        public BaseRepo()
        {
            _db = new GameDataBase();
            _table = _db.Set<T>();
        }

        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }

        public int AddRange(IList<T> entities)
        {
            _table.AddRange(entities);
            return SaveChanges();
        }

        public int Save(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public T GetOne(int? id) => _table.Find(id);

        public virtual List<T> GetAll() => _table.ToList();

        public List<T> ExecuteQuery(string sql) => _table.SqlQuery(sql).ToList();

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
            => _table.SqlQuery(sql,sqlParametersObjects).ToList();

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}

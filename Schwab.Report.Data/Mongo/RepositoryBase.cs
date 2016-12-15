using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using MongoDB.Driver;

using Schwab.Report.Core;


namespace Schwab.Report.Data
{
    public abstract class RepositoryBase<T> where T : class, IEntity<Guid>, new()
    {
        protected DataContext _dbContext;

        private IMongoCollection<T> _collection;

        public IMongoCollection<T> Collection
        {
            get
            {
                if(_collection == null)
                    _collection = _dbContext.GetDatabase().GetCollection<T>(typeof(T).Name.ToLower());

                return _collection;
            }
        }

        public RepositoryBase(string dbName = Databases.Reports)
        {
            _dbContext = new DataContext(dbName);
        }

        public void CreateItems(IEnumerable<T> items)  
        {
            foreach (T item in items)
            {
                CreateItem(item);
            }
        }

        public void CreateItem(T item)
        {
            using (var context = _dbContext)
            {
                Collection.InsertOne(item);
            }
        }

        public void UpdateItems(IEnumerable<T> items)
        {
            foreach(var item in items)
                UpdateItem(item);
        }

        public void UpdateItem(T item)
        {
            using (var context = _dbContext)
            {
               if (item.Id == null)
                    CreateItem(item);

                var filter = Builders<T>.Filter.Eq(x => x.Id, item.Id);

                _collection.ReplaceOne(filter, item); 
            }
        }

        public DeleteResult DeleteItems(Expression<Func<T, bool>> expression)
        {
            using (var context = _dbContext)
            {
                return Collection.DeleteMany<T>(expression);
            }
        }

        public DeleteResult DeleteItem(T document)
        {
            using (var context = _dbContext)
            {
                return Collection.DeleteOne<T>(a => a.Id == document.Id);
            }
        }

        public IQueryable<T> GetAll()
        {
            using (var context = _dbContext)
            {
                return Collection.AsQueryable();
            }
        }

        public T GetById(Guid id)
        {
            using (var context = _dbContext)
            {
                return Collection.Find<T>(x=>x.Id == id).FirstOrDefault();
            }
        }
    }
}
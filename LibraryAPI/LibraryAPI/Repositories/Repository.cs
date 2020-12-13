using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected LibraryContext context;
        public DbSet<T> entities;

        public Repository(LibraryContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Add(T model)
        {
            entities.Add(model);
            Save();
        }

        public void Delete(TKey Id)
        {
            var entity = entities.Find(Id);
            entities.Remove(entity);
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(TKey Id)
        {
            return entities.Find(Id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T model)
        {
            entities.Update(model);
            Save();
        }
    }
}

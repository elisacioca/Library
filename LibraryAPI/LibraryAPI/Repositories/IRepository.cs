using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Repositories
{
    public interface IRepository<T, TKey> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(TKey Id);
        void Add(T model);
        void Delete(TKey Id);
        void Update(T model);
        void Save();

    }
}

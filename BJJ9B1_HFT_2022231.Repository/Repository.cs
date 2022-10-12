using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Repository
{
        public abstract class Repository<T> : IRepository<T> where T : class
        {
            protected F1DbContext DbCont;

            public Repository(F1DbContext DbCont)
            {
                this.DbCont = DbCont;
            }

            public void Create(T item)
            {
                DbCont.Set<T>().Add(item);
                DbCont.SaveChanges();
            }

            public void Delete(int id)
            {
                DbCont.Set<T>().Remove(Read(id));
                DbCont.SaveChanges();
            }
            public IQueryable<T> ReadAll()
            {
                return DbCont.Set<T>();
            }

            public abstract void Update(T item);
            public abstract T Read(int id);
        }
    
}

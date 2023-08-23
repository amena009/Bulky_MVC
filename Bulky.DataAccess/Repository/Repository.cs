using Bulky.DataAccess.Repository.IRepository;
using BulkyMVCWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository
{
    //here we are making our class Repository generic by adding <T>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet; // here we are creating generic DbSet(not just for Categories)
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>(); //here we are setting the current dbSet of type T(generic)
            //means _db.Categories is equal to dbSet
            //means instead of _db.Categpried.Add(), we can use _db.Add()
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
            //above statements is equal to dbSet.Categories.Where(u => u.id == id).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
           dbSet.Remove(entity);    
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
          dbSet.RemoveRange(entities);
        }
    }
}

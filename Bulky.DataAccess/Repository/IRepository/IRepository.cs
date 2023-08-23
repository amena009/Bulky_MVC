using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    //since we are working with generic, we don't know the type, so we'll take it as generic class T
    //so when repo will be implemented, that time we'll know on what class the implementation will be
    //here we'll define base methods needed by any class.
    public interface IRepository<T> where T : class
    {
        //T-category(on this we want to perform CRUD operation or rather we want to interact with DBContext)
        IEnumerable<T> GetAll();   //to get all categories
        T Get(Expression<Func<T, bool>> filter); //basically just general expression for (u => u.id = id), to get by id
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}

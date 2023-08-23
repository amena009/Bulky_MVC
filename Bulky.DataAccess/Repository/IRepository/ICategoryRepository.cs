using BulkyMVCWebApp.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>//so now Category will access base func defined in IRepo
    {
        //along with base functionalities in IRepo, we'll have 2 more methods defined below
        void Update(Category obj);
       // void Save();
       //above line now moved to UnitOfWork
    }
}

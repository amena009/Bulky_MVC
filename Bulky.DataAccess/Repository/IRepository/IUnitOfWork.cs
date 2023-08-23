//the save/update method in CategoryRepository is like a global method irrespective of Category or Product
//but the save functionality is not relevant to the repo or model. it's functionality is very general.
//so we'll have this save in a UnitOfWork
//UnitOfWork is not always required but it's a clean approach
//Pro -  UnitOfWork gives us all registered repos in UnitOfWork repo
//Con - It'll implement all repos registered in UnitOfWork, no matter if you need only 1 repo. 

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        //here we'll register all our repos
        ICategoryRepository Category { get; }
        //and now the global method
        void Save();
    }
}

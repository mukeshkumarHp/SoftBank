using System.Collections.Generic;
using SoftBankApp.Entities;

namespace SoftBankApp.Repositories
{
    public interface IGenericRepository
    { 

    }
    public interface IGenericRepository<TEntity> : IGenericRepository where TEntity : class, IEntity
    {
        void Create(TEntity entity, bool isUpdate = false);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity entity);
    }
}

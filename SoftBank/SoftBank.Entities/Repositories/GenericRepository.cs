using SoftBankApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftBankApp.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly LocalDataContext _localContext;

        public GenericRepository()
        {
            _localContext = new LocalDataContext();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {

            if (typeof(TEntity) == typeof(BankAccounts))
                return _localContext.BankAccounts as IEnumerable<TEntity>;
            else if (typeof(TEntity) == typeof(Users))
                return _localContext.Users as IEnumerable<TEntity>;
            else if (typeof(TEntity) == typeof(Notifications))
                return _localContext.Notifications as IEnumerable<TEntity>;
            else if (typeof(TEntity) == typeof(InvalidKeys))
                return _localContext.InvalidKeys as IEnumerable<TEntity>;
            else if (typeof(TEntity) == typeof(Event))
                return _localContext.Events as IEnumerable<TEntity>;
            else
                throw new NotSupportedException("Not supported type. TEntity not found.");
        }

        public virtual TEntity GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public virtual void Create(TEntity entity, bool isUpdate = false)
        {
            //Autoincrement implementation
            if (!isUpdate)
                entity.Id = GetAll().Count() + 1;

            if (typeof(TEntity) == typeof(Notifications))
                (_localContext.Notifications as List<Notifications>).Add(entity as Notifications);
            else if (typeof(TEntity) == typeof(BankAccounts))
                (_localContext.BankAccounts as List<BankAccounts>).Add(entity as BankAccounts);
            else if (typeof(TEntity) == typeof(InvalidKeys))
                (_localContext.InvalidKeys as List<InvalidKeys>).Add(entity as InvalidKeys);
            else if (typeof(TEntity) == typeof(Event))
                (_localContext.Events as List<Event>).Add(entity as Event);
            else
                throw new InvalidCastException("Unable to cast while creating.");
        }

        public virtual void Update(TEntity entity)
        {
            var entityToUpdate = GetById(entity.Id);

            if (entityToUpdate != null)
            {
                if (typeof(TEntity) == typeof(BankAccounts))
                    _localContext.BankAccounts.ToList().Remove(entityToUpdate as BankAccounts);
                else if (typeof(TEntity) == typeof(Notifications))
                    _localContext.Notifications.ToList().Remove(entityToUpdate as Notifications);
                else
                    throw new InvalidCastException("Unable to cast while creating.");

                Create(entity, isUpdate: true);
            }
        }
    }
}

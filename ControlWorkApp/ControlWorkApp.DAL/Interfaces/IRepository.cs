using System.Collections.Generic;

namespace ControlWorkApp.DAL.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        TEntity Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}

using System.Collections.Generic;

namespace ControlWorkApp.BLL.Interfaces
{
    public interface IService<T>
        where T : class
    {
        T GetById(int itemId);

        List<T> GetAll();

        T Create(T item);

        void Update(T item);

        void Delete(T item);
    }
}

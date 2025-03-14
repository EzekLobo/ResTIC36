using System.Collections.Generic;
using System.Threading.Tasks;

namespace Uesc.Business.Services
{
    public interface IBaseInterface<T>
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task<T> Insert(T entity);
        Task<T?> Update(int id, T entity);
        Task<T?> Delete(int id);
    }
}

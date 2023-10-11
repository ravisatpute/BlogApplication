using System.Linq.Expressions;
using System.Collections;
using System.Linq;
using BlogApiApp.Model;

namespace BlogApiApp.Services
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task <List<ViewModel>> GetStoreProcedureData(int Id);

    }
}

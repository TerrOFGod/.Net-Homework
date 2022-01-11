using System.Threading.Tasks;

namespace DB.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(int id);
    }
}
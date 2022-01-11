using System.Threading.Tasks;
using DB.EF;
using DB.Interface;
using Microsoft.EntityFrameworkCore;

namespace DB.Services
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        // ReSharper disable once MemberCanBeProtected.Global
        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityUp = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entityUp.Entity;
        }

        public async Task<TEntity> FindByIdAsync(int id)
            => await _dbSet.FindAsync(id);
    }
}
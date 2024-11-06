using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity> where TEntity : Entity<int>
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EfRepositoryBase(TContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedTime = DateTime.Now;
            _context.Add(entity);
            return entity;
        }

        public TEntity? Get(Func<TEntity, bool> predicate)
        {
            {
                return _context.Set<TEntity>().FirstOrDefault(predicate);
            }
        }

        public IList<TEntity> GetList(Func<TEntity, bool>? predicate = null)
        {
            IQueryable<TEntity> entities = _context.Set<TEntity>();
            if (predicate is not null)
            {
                entities.Where(predicate).AsQueryable();
            }
            return entities.ToList();
        }
    }
}

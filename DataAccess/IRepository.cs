using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<TEntity>
    {
        public IList<TEntity> GetList(Func<TEntity, bool>? predicate = null);
        public TEntity Add(TEntity entity);
        public TEntity? Get(Func<TEntity, bool> predicate);
    }
}

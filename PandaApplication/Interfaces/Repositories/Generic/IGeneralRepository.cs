using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PandaApplication.Interfaces.Repositories.Generic
{
    public interface IGeneralRepository<TEntity>
    {
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false);

        Task<int> Add(TEntity data);

        Task<int> Update(TEntity data);

        Task<int> Remove(TEntity data);
    }
}

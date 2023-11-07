using Microsoft.EntityFrameworkCore;
using PandaApplication.Interfaces.Repositories.Generic;
using PandaInfrastructure.ConnectionStrings;
using System.Linq.Expressions;

namespace PandaInfrastructure.Repositories.Generic
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
    {
        #region Private Members
        private readonly PandaDbContext _pandaDbContext;
        #endregion

        #region Constructors
        public GeneralRepository() { }
        public GeneralRepository(PandaDbContext pandaDbContext)
        {
            _pandaDbContext = pandaDbContext;
        }
        #endregion


        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = false)
        {
            if (asNoTracking)
                return _pandaDbContext.Set<TEntity>().AsNoTracking().Where(predicate);

            return _pandaDbContext.Set<TEntity>().Where(predicate);
        }

        public async Task<int> Add(TEntity data)
        {
            _pandaDbContext.Set<TEntity>().Add(data);

            return await _pandaDbContext.SaveChangesAsync();
        }

        public async Task<int> Update(TEntity data)
        {
            _pandaDbContext.Set<TEntity>().Update(data);

            return await _pandaDbContext.SaveChangesAsync();
        }

        public async Task<int> Remove(TEntity data)
        {
            _pandaDbContext.Set<TEntity>().Remove(data);

            return await _pandaDbContext.SaveChangesAsync();
        }       
    }
 }

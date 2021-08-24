using LinksoftStudy.Data.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LinksoftStudy.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly Context context;

        public BaseRepository(Context context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await context.AddAsync(entity);
                await context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                context.Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}

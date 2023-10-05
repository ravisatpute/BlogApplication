using BlogApiApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BlogApiApp.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BlogDataContext blogDataContext;
        private DbSet<T> entities;
        public Repository(BlogDataContext repositoryContext)
        {
            blogDataContext = repositoryContext;
            entities = blogDataContext.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            blogDataContext.Set<T>().Add(entity);
            await blogDataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await blogDataContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            blogDataContext.Set<T>().Remove(entity);
            await blogDataContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await blogDataContext.Set<T>().FindAsync(id);
        }


        public async Task<T> Update(T entity)
        {
            blogDataContext.Entry(entity).State = EntityState.Modified;
            await blogDataContext.SaveChangesAsync();
            return entity;
        }
        public async Task<List<T>> GetAll()
        {
            return await blogDataContext.Set<T>().ToListAsync();
        }
        public async Task<List<ViewModel>> GetStoreProcedureData(int Id)
        {
            var result = blogDataContext.Set<ViewModel>().FromSql<ViewModel>(FormattableStringFactory.Create("exec [dbo].[BlogData] "+Id)).ToList();
            return result;
        }
    }
}

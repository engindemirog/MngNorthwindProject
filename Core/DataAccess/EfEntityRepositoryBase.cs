using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>,IAsyncEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //Veri tabanı tablosuna eşleştirme
                var updatedEntity = context.Entry(entity);

                //Hangi işlem uygulanacak? Güncelleme,silme,ekleme
                updatedEntity.State = EntityState.Added;

                //Execute- Çalıştır
                context.SaveChanges();
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            TContext context = new TContext();
            var updatedEntity = context.Entry(entity);

            //Hangi işlem uygulanacak? Güncelleme,silme,ekleme
            updatedEntity.State = EntityState.Added;

            //Execute- Çalıştır
            await context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            TContext context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public List<TEntity> GetAll()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            TContext context = new TContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public TEntity GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().First();
            }
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

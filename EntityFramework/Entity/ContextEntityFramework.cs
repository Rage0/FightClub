using DataModel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class ContextEntityFramework : IRepositoryContext
    {
        private ApplicationDbContext _context;
        public ContextEntityFramework(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public IQueryable<T> GetAllEntityOfDb<T>() where T : class, IEntity
        {
            return DbEntityFactory<T>().AsQueryable();
        }

        public async Task AddEntityToDbAsync<T>(T entity) where T: class, IEntity
        {
            await DbEntityFactory<T>().AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task AddRangeEntityToDbAsync<T>(params T[] entites) where T: class, IEntity
        {
            await DbEntityFactory<T>().AddRangeAsync(entites);
            _context.SaveChanges();
        }

        public void UpdateEntityToDb<T>(T entity) where T: class, IEntity
        {
            DbEntityFactory<T>().Update(entity);
            _context.SaveChanges();
        }

        public void UpdateRangeEntityToDb<T>(params T[] entites) where T: class, IEntity
        {
            DbEntityFactory<T>().UpdateRange(entites);
            _context.SaveChanges();
        }

        public void RemovetEntityToDb<T>(T entity) where T: class, IEntity
        {
            DbEntityFactory<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void RemovetRangeEntityToDb<T>(params T[] entites) where T: class, IEntity
        {
            DbEntityFactory<T>().RemoveRange(entites);
            _context.SaveChanges();
        }

        private DbSet<T> DbEntityFactory<T>() where T : class, IEntity
        {
            return _context.Set<T>();
        }
    }
}

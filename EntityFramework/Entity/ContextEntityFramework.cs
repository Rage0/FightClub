using DataModel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable GetAllEntityOfDb<T>() where T : class, IEntity
        {
            try
            {
               return DbEntityFactory<T>().AsQueryable();
            }
            catch (Exception)
            {
                throw new Exception("Database output error");
            }
        }

        public async Task AddEntityToDbAsync<T>(T entity) where T: class, IEntity
        {
            try
            {
                await DbEntityFactory<T>().AddAsync(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error adding from database");
            }
        }

        public async Task AddRangeEntityToDbAsync<T>(params T[] entites) where T: class, IEntity
        {
            try
            {
                await DbEntityFactory<T>().AddRangeAsync(entites);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error range adding from database");
            }
        }

        public void UpdateEntityToDb<T>(T entity) where T: class, IEntity
        {
            try
            {
                DbEntityFactory<T>().Update(entity); 
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error updating from database");
            }
        }

        public void UpdateRangeEntityToDb<T>(params T[] entites) where T: class, IEntity
        {
            try
            {
                DbEntityFactory<T>().UpdateRange(entites);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error range updating from database");
            }
        }

        public void RemovetEntityToDb<T>(T entity) where T: class, IEntity
        {
            try
            {
                DbEntityFactory<T>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error removing from database");
            }
        }

        public void RemovetRangeEntityToDb<T>(params T[] entites) where T: class, IEntity
        {
            try
            {
                DbEntityFactory<T>().RemoveRange(entites);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error range removing from database");
            }
        }

        private DbSet<T> DbEntityFactory<T>() where T : class, IEntity
        {
            return _context.Set<T>();
        }
    }
}

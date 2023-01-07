using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Interfaces
{
    public interface IRepositoryContext
    {
        public IQueryable<T> GetAllEntityOfDb<T>() where T : class, IEntity;
        public Task AddEntityToDbAsync<T>(T entity) where T : class, IEntity;
        public Task AddRangeEntityToDbAsync<T>(params T[] entites) where T: class, IEntity;
        public void UpdateEntityToDb<T>(T entity) where T: class, IEntity;
        public void UpdateRangeEntityToDb<T>(params T[] entites) where T: class, IEntity;
        public void RemovetEntityToDb<T>(T entity) where T: class, IEntity;
        public void RemovetRangeEntityToDb<T>(params T[] entites) where T: class, IEntity;
    }
}

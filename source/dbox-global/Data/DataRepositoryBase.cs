using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dbox_global.Contracts;
using dbox_global.Utils;

namespace dbox_global.Data
{
    /// <summary>
    /// Data repository abstract base class.
    /// </summary>
    /// <typeparam name="T">Type of repository</typeparam>
    /// <typeparam name="TC">Type of context</typeparam>
    /// <typeparam name="TI">Type of id</typeparam>
    public abstract class DataRepositoryBase<T, TC, TI> : IDataRepository<T, TI>
        where T : class, new()
        where TC : new()
    {
        protected readonly TC Context;

        public DataRepositoryBase(TC context)
        {
            Context = context;
        }

        protected abstract T AddEntity(T entity);

        protected abstract T UpdateEntity(T entity);

        protected abstract IEnumerable<T> GetEntities();

        protected abstract T GetEntity(TI id);

        protected abstract void RemoveEntity(T entity);
        protected abstract void RemoveEntity(TI id);

        protected abstract long Count();

        public T Add(T entity)
        {
            var addedEntity = AddEntity(entity);
            return addedEntity;
        }

        public void Remove(T entity)
        {
            RemoveEntity(entity);
        }

        public void Remove(TI id)
        {
            RemoveEntity(id);
        }

        public T Update(T entity)
        {
            var existingEntity = UpdateEntity(entity);

            SimpleMapper.PropertyMap(entity, existingEntity);

            return existingEntity;
        }

        public IEnumerable<T> GetAll()
        {
            return (GetEntities()).ToArray().ToList();
        }

        public T Get(TI id)
        {
            return GetEntity(id);
        }

        public long Total()
        {
            return Count();
        }
    }
}

using System.Collections.Generic;

namespace dbox_global.Contracts
{
    public interface IDataRepository
    {
    }

    /// <summary>
    /// Data repository interface
    /// </summary>
    /// <typeparam name="T">Type of repository</typeparam>
    /// <typeparam name="TI">Type of id</typeparam>
    public interface IDataRepository<T, TI> : IDataRepository
        where T : class, new()
    {
        T Add(T entity);

        void Remove(T entity);

        void Remove(TI id);

        T Update(T entity);

        IEnumerable<T> GetAll();

        T Get(TI id);

        long Total();
    }
}

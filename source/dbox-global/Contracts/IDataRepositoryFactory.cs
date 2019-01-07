namespace dbox_global.Contracts
{
    public interface IDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : IDataRepository;
    }
}
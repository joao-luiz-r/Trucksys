namespace TruckSys.Domain.Interfaces.Repository
{
    public interface IEFRepository<T> where T : class 
    {
        T Add(T entity);    
        T Update(T entity);     
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}

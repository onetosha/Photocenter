namespace Photocenter.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> Get(int id);
    }
}

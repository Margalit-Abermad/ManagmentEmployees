namespace Service
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> CreateAsync(T obj);
        Task<bool> DeleteAsync(string id);
        Task<T> UpdateAsync(T obj);
    }
}


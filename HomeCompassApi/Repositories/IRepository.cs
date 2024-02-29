namespace HomeCompassApi.BLL
{
    public interface IRepository<T>
    {
<<<<<<< HEAD
        Task Add(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Update(T entity);
        Task Delete(int id);
=======
        void Add(T entity);
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(int id);
        bool IsExisted(T entity);
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b
    }
}

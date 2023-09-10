namespace EmploymentProjectTeam02.Common.Base;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetById(int id);
    Task<IEnumerable<TEntity>> GetAll();
    Task Insert(TEntity entity);
    Task Update(int id, TEntity entity);
    Task<TEntity> Delete(int id);
}

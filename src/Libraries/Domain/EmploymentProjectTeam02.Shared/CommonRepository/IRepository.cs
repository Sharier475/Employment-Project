using EmploymentProjectTeam02.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Shared.CommonRepository
{
    public interface IRepository<TEntity, IModel,T>
        where TEntity : class, IEntity<T>, new()
        where IModel : class, IVm<T>
        where T : IEquatable<T>
    {
        public Task<IModel> GetById(T id);
        public Task<IEnumerable<IModel>> GetList();
        public Task<List<IModel>> GetList(params Expression<Func<TEntity, object>>[] includes);
        public Task<IModel> Delete(T id);
        public Task<IModel> Update(T id, TEntity entity);
        public Task<IModel> Add(TEntity entity);
    }
}

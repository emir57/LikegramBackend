using Likegram.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.DataAccess
{
    public interface IEntityRepository<T>
        where T : BaseEntity, new()
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll();
    }
}

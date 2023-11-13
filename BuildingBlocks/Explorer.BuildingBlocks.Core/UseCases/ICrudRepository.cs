using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.BuildingBlocks.Core.UseCases
{
    public interface ICrudRepository<TEntity> where TEntity : Entity
    {
        PagedResult<TEntity> GetPaged(int page, int pageSize);
        TEntity Get(long id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(long id);
    }
}

using ISAProject.Configuration.Core.Domain;

// Preuzeto kao šablon sa projekta iz predmeta PSW

namespace ISAProject.Configuration.Core.UseCases
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

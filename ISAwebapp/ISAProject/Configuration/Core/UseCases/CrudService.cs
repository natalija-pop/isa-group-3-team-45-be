using AutoMapper;
using FluentResults;
using ISAProject.Configuration.Core.Domain;

// Preuzeto kao šablon sa projekta iz predmeta PSW

namespace ISAProject.Configuration.Core.UseCases
{
    public abstract class CrudService<TDto, TDomain> : MappingService<TDto, TDomain> where TDomain : Entity
    {
        protected readonly ICrudRepository<TDomain> CrudRepository;

        protected CrudService(ICrudRepository<TDomain> crudRepository, IMapper mapper) : base(mapper)
        {
            CrudRepository = crudRepository;
        }

        public Result<PagedResult<TDto>> GetPaged(int page, int pageSize)
        {
            var result = CrudRepository.GetPaged(page, pageSize);
            return MapToDto(result);
        }

        public Result<TDto> Get(int id)
        {
            try
            {
                var result = CrudRepository.Get(id);
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public virtual Result<TDto> Create(TDto entity)
        {
            try
            {
                var result = CrudRepository.Create(MapToDomain(entity));
                return MapToDto(result);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public virtual Result<TDto> Update(TDto entity)
        {
            try
            {
                var result = CrudRepository.Update(MapToDomain(entity));
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public virtual Result Delete(int id)
        {
            try
            {
                CrudRepository.Delete(id);
                return Result.Ok();
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

    }
}

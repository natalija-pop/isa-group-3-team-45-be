// Preuzeto kao šablon sa projekta iz predmeta PSW

namespace ISAProject.Configuration.Core.UseCases
{
    public class PagedResult<T>
    {
        public List<T> Results { get; }
        public int TotalCount { get; }

        public PagedResult(List<T> items, int totalCount)
        {
            TotalCount = totalCount;
            Results = items;
        }
    }
}

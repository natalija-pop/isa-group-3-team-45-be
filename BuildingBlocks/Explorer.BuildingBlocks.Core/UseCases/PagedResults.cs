using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.BuildingBlocks.Core.UseCases
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

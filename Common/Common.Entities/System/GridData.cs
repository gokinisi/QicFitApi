
using System.Collections.Generic;

namespace Common.Entities.System
{
    public class GridData<TDto> where TDto: class, new()
    {
        public int TotalCount { get; set; }
        public IEnumerable<TDto> Items { get; set; }
    }
}
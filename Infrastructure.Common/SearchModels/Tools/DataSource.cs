using System.Linq;

namespace Infrastructure.Common.SearchModels.Tools
{
    public class DataSource
    {
        public IQueryable Data { get; set; }
        public int Count { get; set; }
    }
}

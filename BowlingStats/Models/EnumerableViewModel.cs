using Entities;

namespace BowlingStats.Models
{
    public class EnumerableViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public EnumerableViewModel()
        {
            Items = new HashSet<T>();
        }
    }
}

using ClassLibrary.Filters;

namespace ClassLibrary.Filter;
public class BaseFilter : IFilter
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 50;
}

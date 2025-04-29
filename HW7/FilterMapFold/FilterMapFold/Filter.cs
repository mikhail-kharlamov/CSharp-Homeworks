namespace FilterMapFold;

public static partial class HigherOrderFunctions
{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
}
namespace FilterMapFold;

public static partial class HigherOrderFunctions
{
    public static IEnumerable<T> Map<T>(this IEnumerable<T> source, Func<T, T> func)
    {
        foreach (var item in source)
        {
            yield return func(item);
        }
    }
}
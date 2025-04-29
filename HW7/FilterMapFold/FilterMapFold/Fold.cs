namespace FilterMapFold;

public static partial class HigherOrderFunctions
{
    public static int Fold(IEnumerable<int> source, Func<int, int, int> function) //TODO make lazy
    {
        var collection = source.ToList();
        var result = collection[0];
        for (var i = 1; i < collection.Count; i++)
        {
            result = function(result, collection[i]);
        }
        return result;
    }
}
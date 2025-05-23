// Copyright (c) 2025 Mikhail Kharlamov. Licensed under MIT License.

namespace Credit;

/// <summary>
/// Provides utility methods for working with <see cref="CustomList{T}"/> collections
/// </summary>
public static class ListUtils
{
    /// <summary>
    /// Counts the number of elements in the list that are considered null according to the specified checker
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    /// <param name="list">The list to examine</param>
    /// <param name="nullChecker">The null-checking strategy to use</param>
    /// <returns>The number of null elements found</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if either list or nullChecker parameters are null
    /// </exception>
    /// <example>
    /// <code>
    /// var list = new CustomList&lt;int&gt;() { 1, 0, 2, 0, 3 };
    /// var checker = new IntNullChecker();
    /// int nullCount = ListUtils.CountNullElements(list, checker);
    /// // nullCount will be 2
    /// </code>
    /// </example>
    public static int CountNullElements<T>(CustomList<T> list, INullChecker<T> nullChecker)
    {
        int count = 0;
        foreach (var item in list)
        {
            if (nullChecker.IsNull(item))
            {
                count++;
            }
        }
        return count;
    }
}
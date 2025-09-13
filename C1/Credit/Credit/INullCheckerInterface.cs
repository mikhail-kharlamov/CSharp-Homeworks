// Copyright (c) 2025 Mikhail Kharlamov. Licensed under MIT License.

namespace Credit;

/// <summary>
/// Interface for determining whether an element should be considered "null" or empty
/// </summary>
/// <typeparam name="T">The type of elements to check</typeparam>
/// <remarks>
/// Implement this interface to provide custom null-checking logic for specific types.
/// Useful when the standard null concept doesn't apply (e.g., for value types).
/// </remarks>
public interface INullChecker<T>
{
    /// <summary>
    /// Determines whether the specified item should be considered "null" according to custom criteria
    /// </summary>
    /// <param name="item">The item to check</param>
    /// <returns>
    /// <c>true</c> if the item meets the null criteria; otherwise, <c>false</c>
    /// </returns>
    /// <example>
    /// For integers, might consider 0 as null:
    /// <code>
    /// public bool IsNull(int item) => item == 0;
    /// </code>
    /// </example>
    bool IsNull(T item);
}
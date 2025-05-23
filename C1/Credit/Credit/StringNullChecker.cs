// Copyright (c) 2025 Mikhail Kharlamov. Licensed under MIT License.

namespace Credit;

/// <summary>
/// Implementation of <see cref="INullChecker{T}"/> for strings
/// </summary>
/// <remarks>
/// Treats both null references and empty strings as "null" values.
/// This matches the behavior of <see cref="string.IsNullOrEmpty"/>.
/// </remarks>
public class StringNullChecker : INullChecker<string>
{
    /// <summary>
    /// Determines whether the string is null or empty
    /// </summary>
    /// <param name="item">The string to check</param>
    /// <returns>true if the string is null or empty; otherwise, false</returns>
    public bool IsNull(string item) => string.IsNullOrEmpty(item);
}
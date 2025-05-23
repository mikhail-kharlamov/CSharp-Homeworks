// Copyright (c) 2025 Mikhail Kharlamov. Licensed under MIT License.

namespace Credit;

/// <summary>
/// Implementation of <see cref="INullChecker{T}"/> for integers where 0 is considered null
/// </summary>
/// <remarks>
/// This checker treats the integer value 0 as a null equivalent,
/// which is useful for counting zero values in collections.
/// </remarks>
public class IntNullChecker : INullChecker<int>
{
    /// <summary>
    /// Determines whether the specified integer is considered null (equal to 0)
    /// </summary>
    /// <param name="item">The integer to check</param>
    /// <returns>true if the integer is 0; otherwise, false</returns>
    public bool IsNull(int item) => item == 0;
}
// Copyright (c) 2025 Mikhail Kharlamov. Licensed under MIT License.

namespace Credit;

/// <summary>
/// Generic implementation of <see cref="INullChecker{T}"/> for reference types
/// </summary>
/// <typeparam name="T">The reference type to check</typeparam>
/// <remarks>
/// Uses standard reference equality comparison (item == null) to determine null status.
/// Suitable for any class type where standard null checking is appropriate.
/// </remarks>
public class ReferenceNullChecker<T> : INullChecker<T> where T : class
{
    /// <summary>
    /// Determines whether the specified reference is null
    /// </summary>
    /// <param name="item">The object reference to check</param>
    /// <returns>true if the reference is null; otherwise, false</returns>
    public bool IsNull(T item) => item is null;
}
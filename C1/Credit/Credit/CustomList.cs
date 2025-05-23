// Copyright (c) 2025 Mikhail Kharlamov. Licensed under MIT License.

namespace Credit;

using System;
using System.Collections.Generic;

/// <summary>
/// A generic dynamically-resizing list implementation that provides
/// basic collection functionality with O(1) amortized insertion time.
/// </summary>
/// <typeparam name="T">The type of elements in the list</typeparam>
public class CustomList<T> : IEnumerable<T>
{
    private const int startLength = 10;
    
    private T[] items = new T[startLength];
    
    private int count = 0;
    
    private void Realloc()
    {
        T[] newItems = new T[items.Length * 2];
        Array.Copy(items, newItems, this.count);
    }

    /// <summary>
    /// Adds an item to the end of the CustomList
    /// </summary>
    /// <param name="item">The object to add to the list</param>
    /// <remarks>
    /// This method operates in amortized O(1) time.
    /// When capacity is reached, reallocation doubles the storage size.
    /// </remarks>
    public void Add(T item)
    {
        if (count == items.Length)
        {
            this.Realloc();
        }
        this.items[count] = item;
        count++;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the CustomList
    /// </summary>
    /// <returns>An enumerator for the list contents</returns>
    public IEnumerator<T> GetEnumerator()
    {
        var startCount = this.count;
        for (int i = 0; i < count; i++)
        {
            if (this.count > startCount)
            {
                throw new InvalidOperationException("Collection was modified");
            }
            yield return items[i];
        }
    }
    
    /// <summary>
    /// Explicit interface implementation for non-generic enumeration
    /// </summary>
    /// <returns>Non-generic enumerator</returns>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
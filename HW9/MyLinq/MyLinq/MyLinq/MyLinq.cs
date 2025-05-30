// <copyright file="SparseVector.cs" company="Mikhail Kharlamov">
// Copyright (c) Mikhail Kharlamov. All rights reserved.
// </copyright>

namespace MyLinq;

using System;
using System.Collections.Generic;

public static class MyLinq
{
    public static IEnumerable<int> GetPrimes()
    {
        yield return 2;

        var number = 3;
        while (true)
        {
            if (IsPrime(number))
            {
                yield return number;
            }

            number += 2;
        }
    }

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> seq, int n)
    {
        using var enumerator = seq.GetEnumerator();

        for (var i = 0; i < n; i++)
        {
            if (!enumerator.MoveNext())
            {
                yield break;
            }
        }

        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }
    }

    public static IEnumerable<T> Take<T>(this IEnumerable<T> seq, int n)
    {
        using var enumerator = seq.GetEnumerator();

        for (var i = 0; i < n; i++)
        {
            if (!enumerator.MoveNext())
            {
                yield break;
            }
            
            yield return enumerator.Current;
        }
    }

    private static bool IsPrime(int number)
    {
        for (int i = 3; i <= (int)Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
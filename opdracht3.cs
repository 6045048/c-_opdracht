using System;
using System.Collections.Generic;

public static class MyListExtensions
{
    // Select: creates a new list with transformed values
    public static IEnumerable<TResult> Select<T, TResult>(
        this IMyList<T> source,
        Func<T, TResult> selector)
    {
        foreach (var item in source)
        {
            yield return selector(item);
        }
    }

    // Where: filters elements based on a condition
    public static IEnumerable<T> Where<T>(
        this IMyList<T> source,
        Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                yield return item;
        }
    }

    // Count: counts all elements (optionally with a filter)
    public static int Count<T>(
        this IMyList<T> source,
        Func<T, bool>? predicate = null)
    {
        int count = 0;
        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
                count++;
        }
        return count;
    }

    // Any: checks if there is at least one element (optionally with a filter)
    public static bool Any<T>(
        this IMyList<T> source,
        Func<T, bool>? predicate = null)
    {
        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
                return true;
        }
        return false;
    }

    // FirstOrDefault: returns the first element (or default if empty or no match)
    public static T FirstOrDefault<T>(
        this IMyList<T> source,
        Func<T, bool>? predicate = null)
    {
        foreach (var item in source)
        {
            if (predicate == null || predicate(item))
                return item;
        }
        return default!;
    }
}

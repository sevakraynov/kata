using System.Linq;

namespace Kata.Tasks.ArrayDiff;

/// <summary>
/// Класс для решения задачи Array.Diff
/// </summary>
/// <remarks>
/// 
/// <see cref="https://www.codewars.com/kata/523f5d21c841566fde000009">TASK</see>:
/// Your goal in this kata is to implement a difference function, 
/// which subtracts one list from another and returns the result.
/// 
/// It should remove all values from list a, which are present in list b.
/// Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}
/// 
/// If a value is present in b, all of its occurrences must be removed from the other:
/// Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}
/// </remarks>
public static class ArrayDiff
{
    public static int[] Diff(int[] a, int[] b)
        => a.Where(q => !b.Contains(q)).ToArray();
}

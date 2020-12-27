# [Array.diff](https://www.codewars.com/kata/523f5d21c841566fde000009)

## Условие

Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.

## Примеры

It should remove all values from list a, which are present in list b.

```csharp
Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}
```
If a value is present in b, all of its occurrences must be removed from the other:

```csharp
Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}
```

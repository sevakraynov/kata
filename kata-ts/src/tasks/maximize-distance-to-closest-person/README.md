# [Maximize Distance to Closest Person](https://leetcode.com/problems/maximize-distance-to-closest-person)

## Условие

You are given an array representing a row of `seats` where `seats[i] = 1` represents a person sitting in the `i-th` seat, and `seats[i] = 0` represents that the `i-th` seat is empty **(0-indexed)**.

There is at least one empty seat, and at least one person sitting.

Alex wants to sit in the seat such that the distance between him and the closest person to him is maximized.

Return *that maximum distance to the closest person*.

## Примеры

```bash
# Пример 1
Input: seats = [1,0,0,0,1,0,1]
Output: 2
```

```bash
# Пример 2
Input: seats = [1,0,0,0]
Output: 3
```

```bash
# Пример 3
Input: seats = [0,1]
Output: 1
```

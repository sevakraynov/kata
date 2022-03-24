# [Score of Parentheses](https://leetcode.com/problems/score-of-parentheses/)

## Условие

Given a balanced parentheses string `s`, return _the **score** of the string_.

The **score** of a balanced parentheses string is based on the following rule:

* `"()"` has score `1`.
* `AB` has score `A + B`, where `A` and `B` are balanced parentheses strings.
* `(A)` has score `2 * A`, where `A` is a balanced parentheses string.

## Примеры

```bash
# Пример 1
Input: s = "()"
Output: 1
```

```bash
# Пример 2
Input: s = "(())"
Output: 2
```

```bash
# Пример 3
Input: s = "()()"
Output: 2
```

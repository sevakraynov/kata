import { searchMatrix } from "./search-in-matrix";

const cases: { matrix: number[][]; target: number; result: boolean }[] = [
  {
    matrix: [[1]],
    target: 1,
    result: true,
  },
  {
    matrix: [[0]],
    target: 1,
    result: false,
  },
  {
    matrix: [
      [1, 3, 5, 7],
      [10, 11, 16, 20],
      [23, 30, 34, 60],
    ],
    target: 3,
    result: true,
  },
  {
    matrix: [
      [1, 3, 5, 7],
      [10, 11, 16, 20],
      [23, 30, 34, 60],
    ],
    target: 13,
    result: false,
  },
];

describe("search-in-matrix", () => {
  test.each(cases)("case #%#", ({ matrix, target, result }) => {
    expect(searchMatrix(matrix, target)).toBe(result);
  });
});

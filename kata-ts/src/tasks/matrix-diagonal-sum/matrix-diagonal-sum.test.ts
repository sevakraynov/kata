import { diagonalSum } from "./matrix-diagonal-sum";

const cases: { matrix: number[][]; sum: number }[] = [
  {
    matrix: [
      [1, 2, 3],
      [4, 5, 6],
      [7, 8, 9],
    ],
    sum: 25,
  },
  {
    matrix: [
      [7, 3, 1, 9],
      [3, 4, 6, 9],
      [6, 9, 6, 6],
      [9, 5, 8, 5],
    ],
    sum: 55,
  },
  {
    matrix: [
      [1, 1, 1, 1],
      [1, 1, 1, 1],
      [1, 1, 1, 1],
      [1, 1, 1, 1],
    ],
    sum: 8,
  },
];

describe("matrix-diagonal-sum", () => {
  test.each(cases)("case #%#", ({ matrix, sum }) => {
    const result = diagonalSum(matrix);
    expect(result).toBe(sum);
  });
});

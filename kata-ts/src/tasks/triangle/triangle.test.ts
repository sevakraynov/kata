import { minimumTotal } from "./triangle";

const cases: { triangle: number[][], expected: number }[] = [
  {
    triangle: [[2],[3,4],[6,5,7],[4,1,8,3]],
    expected: 11,
  },
  {
    triangle: [[-10]],
    expected: -10
  }
];

describe("triangle", () => {
  test.each(cases)("case #%#", ({ triangle, expected }) => {
    const result = minimumTotal(triangle);
    expect(result).toBe(expected);
  });
});

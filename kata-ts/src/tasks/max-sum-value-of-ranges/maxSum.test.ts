import maxSum from "./maxSum";

describe("the maximum sum value of ranges -- challenge version", () => {
  test("maximum is 6", () => {
    expect(
      maxSum(
        [1, -2, 3, 4, -5, -4, 3, 2, 1],
        [
          [1, 3],
          [0, 4],
          [6, 8],
        ]
      )
    ).toBe(6);
  });

  test("maximum is 5", () => {
    expect(maxSum([1, -2, 3, 4, -5, -4, 3, 2, 1], [[1, 3]])).toBe(5);
  });

  test("maximum is 0", () => {
    expect(
      maxSum(
        [1, -2, 3, 4, -5, -4, 3, 2, 1],
        [
          [1, 4],
          [2, 5],
        ]
      )
    ).toBe(0);
  });
});

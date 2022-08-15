import { findMaxConsecutiveOnes } from "./find-max-consecutive-ones";

describe("find-max-consecutive-ones", () => {
  test.each`
    nums                  | expected
    ${[1, 1, 0, 1, 1, 1]} | ${3}
    ${[1, 0, 1, 1, 0, 1]} | ${2}
  `("returns $expected when input $nums", ({ nums, expected }) => {
    const max = findMaxConsecutiveOnes(nums);
    expect(max).toStrictEqual(expected);
  });
});

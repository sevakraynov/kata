import { singleNonDuplicate } from "./single-in-sorted-array";

describe("singleNonDuplicate tests", () => {
  test.each`
    nums                                 | expected
    ${[1, 1, 2, 3, 3, 4, 4, 8, 8]}       | ${2}
    ${[0, 0, 1, 1, 2, 3, 3, 4, 4, 8, 8]} | ${2}
    ${[3, 3, 7, 7, 10, 11, 11]}          | ${10}
  `("returns $expected when input $nums", ({ nums, expected }) => {
    const u = singleNonDuplicate(nums);
    expect(u).toBe(expected);
  });
});

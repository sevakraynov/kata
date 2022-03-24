import { searchRange } from "./first-and-last-el-in-sorted-array";

describe("find first and last position of element in sorted array", () => {
  test.each`
    nums                   | target | expected
    ${[5, 7, 7, 8, 8, 10]} | ${8}   | ${[3, 4]}
    ${[5, 7, 7, 8, 8, 10]} | ${6}   | ${[-1, -1]}
    ${[]}                  | ${0}   | ${[-1, -1]}
  `("returns $expected when $nums and $target passed to function", ({ nums, target, expected }) => {
    expect(searchRange(nums, target)).toEqual(expected);
  });
});

import findDisappearedNumbers from "./disappeared-numbers";

describe("find disappeared numbers tests", () => {
  test.each`
    nums                        | expected
    ${[4, 3, 2, 7, 8, 2, 3, 1]} | ${[5, 6]}
    ${[1, 1]}                   | ${[2]}
  `("returns $expected when input $nums", ({ nums, expected }) => {
    const findedNumbers = findDisappearedNumbers(nums);
    expect(findedNumbers).toStrictEqual(expected);
  });
});

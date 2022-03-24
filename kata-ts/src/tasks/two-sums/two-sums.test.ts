import { twoSums, twoSumsBinarySearch, twoSumsN2, twoSumsPointers, twoSumsSet } from "./two-sums";

describe("task two sums", () => {
  test.each`
    numbers              | k    | expected
    ${[-1, 2, 5, 9]}     | ${7} | ${[2, 5]}
    ${[-3, -1, 0, 2, 6]} | ${6} | ${[0, 6]}
    ${[2, 4, 5]}         | ${8} | ${[]}
  `("returns $expected when $numbers and $k passed to function", ({ numbers, k, expected }) => {
    const resultN2 = twoSumsN2(numbers, k);
    const resultSet = twoSumsSet(numbers, k);
    const resultBinarySearch = twoSumsBinarySearch(numbers, k);
    const resultPointers = twoSumsPointers(numbers, k);

    expect(resultN2).toEqual(expected);
    expect(resultSet).toEqual(expected);
    expect(resultBinarySearch).toEqual(expected);
    expect(resultPointers).toEqual(expected);
  });

  test.each`
    numbers           | k    | expected
    ${[2, 7, 11, 15]} | ${9} | ${[0, 1]}
    ${[3, 2, 4]}      | ${6} | ${[1, 2]}
    ${[3, 3]}         | ${6} | ${[0, 1]}
  `("returns $expected when $numbers and $k passed to function", ({ numbers, k, expected }) => {
    expect(twoSums(numbers, k)).toEqual(expected);
  });
});
